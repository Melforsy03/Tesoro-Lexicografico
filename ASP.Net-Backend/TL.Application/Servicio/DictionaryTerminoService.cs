using Microsoft.EntityFrameworkCore;
using TL.Application.DTOs;
using TL.Application.Interfaces;
using TL.Domain.Relaciones;
using TL.Infrastructure;

namespace TL.Application.Services
{
    public class DiccionarioTerminoService : IDiccionarioTerminoService
    {
        private readonly Context _context;

        public DiccionarioTerminoService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiccionarioTerminoDTO>> ObtenerTodosAsync()
        {
            return await _context.Entradas
                .Select(x => new DiccionarioTerminoDTO
                {
                    IdDicTer = x.IdDicTer,
                    IdDic = x.IdDic,
                    IdTer = x.IdTer,
                    NomEntrada = x.NomEntrada,
                    EsSuperEntrada = x.EsSuperEntrada,
                    EsSubEntrada = x.EsSubEntrada
                })
                .ToListAsync();
        }

        public async Task<DiccionarioTerminoDTO> ObtenerPorIdAsync(int id)
        {
            var item = await _context.Entradas.FindAsync(id);
            if (item == null) return null;

            return new DiccionarioTerminoDTO
            {
                IdDicTer = item.IdDicTer,
                IdDic = item.IdDic,
                IdTer = item.IdTer,
                NomEntrada = item.NomEntrada,
                EsSuperEntrada = item.EsSuperEntrada,
                EsSubEntrada = item.EsSubEntrada
            };
        }

        public async Task<DiccionarioTerminoDTO> CrearAsync(DiccionarioTerminoDTO dto)
        {
            var nuevo = new DiccionarioTermino
            {
                IdDic = dto.IdDic,
                IdTer = dto.IdTer,
                NomEntrada = dto.NomEntrada,
                EsSuperEntrada = dto.EsSuperEntrada,
                EsSubEntrada = dto.EsSubEntrada
            };

            _context.Entradas.Add(nuevo);
            await _context.SaveChangesAsync();

            dto.IdDicTer = nuevo.IdDicTer;
            return dto;
        }
    }
}
