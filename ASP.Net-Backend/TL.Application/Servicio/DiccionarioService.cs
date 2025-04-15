using Microsoft.EntityFrameworkCore;
using TL.Application.DTOs;
using TL.Application.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure;

namespace TL.Application.Services
{
    public class DiccionarioService : IDiccionarioService
    {
        private readonly Context _context;

        public DiccionarioService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiccionarioDTO>> ObtenerTodosAsync()
        {
            return await _context.Diccionarios
                .Select(d => new DiccionarioDTO
                {
                    IdDic = d.IdDic,
                    DicNombre = d.DicNombre
                })
                .ToListAsync();
        }

        public async Task<DiccionarioDTO> ObtenerPorIdAsync(int id)
        {
            var dic = await _context.Diccionarios.FindAsync(id);
            if (dic == null) return null;

            return new DiccionarioDTO
            {
                IdDic = dic.IdDic,
                DicNombre = dic.DicNombre
            };
        }

        public async Task<DiccionarioDTO> CrearAsync(DiccionarioDTO dto)
        {
            var nuevo = new Diccionario
            {
                DicNombre = dto.DicNombre
            };

            _context.Diccionarios.Add(nuevo);
            await _context.SaveChangesAsync();

            dto.IdDic = nuevo.IdDic;
            return dto;
        }
    }
}
