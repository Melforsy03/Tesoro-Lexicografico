using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TL.Application.ApplicationServices.DTOs;
using TL.Application.ApplicationServices.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure;

namespace TL.Application.ApplicationServices.Servicio
{
    public class EditorService : IEditorService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EditorService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<EditorDTO>> ObtenerTodosAsync()
        {
            var editores = await _context.Editores.ToListAsync();
            List<EditorDTO> editorDtos = new List<EditorDTO>();
            for (int i = 0; i < editores.Count(); i++)
            {
                var edDto = _mapper.Map<EditorDTO>(editores[i]);
                editorDtos.Add(edDto);
            }
            if (editorDtos.Count == 0) return null;
            return editorDtos;
        }

        public async Task<EditorDTO> ObtenerPorIdAsync(int id)
        {
            var editor = await _context.Editores.FindAsync(id);
            if (editor == null) return null;
            return _mapper.Map<EditorDTO>(editor);
        }

        public async Task<EditorDTO> CrearAsync(EditorDTO dto)
        {
            if (dto == null) return null;
            var editor = _mapper.Map<Editor>(dto);
            await _context.Editores.AddAsync(editor);
            await _context.SaveChangesAsync();

            return _mapper.Map<EditorDTO>(editor);
        }

        public async Task<EditorDTO> BorrarAsync(int Id)
        {
            var editor = await _context.Editores.FindAsync(Id);
            if (editor == null) return null;
            var editorDto = _mapper.Map<EditorDTO>(editor);
            
            _context.Editores.Remove(editor);
            await _context.SaveChangesAsync();
            
            return editorDto;
        }
    }
}
