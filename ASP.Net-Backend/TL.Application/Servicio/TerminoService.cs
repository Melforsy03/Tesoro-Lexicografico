using Microsoft.EntityFrameworkCore;
using TL.Application.DTOs;
using TL.Application.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure;

namespace TL.Application.Services
{
    public class TerminoService : ITerminoService
    {
        private readonly Context _context;

        public TerminoService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TerminoDTO>> ObtenerTodosAsync()
        {
            return await _context.Terminos
                .Select(t => new TerminoDTO
                {
                    IdTer = t.IdTer,
                    NomReg = t.NomReg
                })
                .ToListAsync();
        }

        public async Task<TerminoDTO> ObtenerPorIdAsync(int id)
        {
            var term = await _context.Terminos.FindAsync(id);
            if (term == null) return null;

            return new TerminoDTO
            {
                IdTer = term.IdTer,
                NomReg = term.NomReg
            };
        }

        public async Task<TerminoDTO> CrearAsync(TerminoDTO dto)
        {
            var nuevo = new Termino
            {
                NomReg = dto.NomReg
            };

            _context.Terminos.Add(nuevo);
            await _context.SaveChangesAsync();

            dto.IdTer = nuevo.IdTer;
            return dto;
        }
    }
}
