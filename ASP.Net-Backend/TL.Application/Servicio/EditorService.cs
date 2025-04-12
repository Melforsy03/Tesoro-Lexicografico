using Microsoft.EntityFrameworkCore;
using TL.Application.DTOs;
using TL.Application.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure;

namespace TL.Application.Services
{
    public class EditorService : IEditorService
    {
        private readonly Context _context;

        public EditorService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EditorDTO>> ObtenerTodosAsync()
        {
            return await _context.Editores
                .Select(e => new EditorDTO
                {
                    IdEd = e.IdEd,
                    NomEd = e.NomEd,
                    EsAdmin = e.EsAdmin
                })
                .ToListAsync();
        }

        public async Task<EditorDTO> ObtenerPorIdAsync(int id)
        {
            var editor = await _context.Editores.FindAsync(id);
            if (editor == null) return null;

            return new EditorDTO
            {
                IdEd = editor.IdEd,
                NomEd = editor.NomEd,
                EsAdmin = editor.EsAdmin
            };
        }

        public async Task<EditorDTO> CrearAsync(EditorDTO dto)
        {
            var nuevo = new Editor
            {
                NomEd = dto.NomEd,
                EsAdmin = dto.EsAdmin
            };

            _context.Editores.Add(nuevo);
            await _context.SaveChangesAsync();

            dto.IdEd = nuevo.IdEd;
            return dto;
        }
    }
}
