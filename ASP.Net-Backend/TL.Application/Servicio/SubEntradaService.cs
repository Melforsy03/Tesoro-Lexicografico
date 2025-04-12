using Microsoft.EntityFrameworkCore;
using TL.Application.DTOs;
using TL.Application.Interfaces;
using TL.Domain.Relaciones;
using TL.Infrastructure;

namespace TL.Application.Services
{
    public class SubEntradaService : ISubEntradaService
    {
        private readonly Context _context;

        public SubEntradaService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubEntradaDTO>> ObtenerTodasAsync()
        {
            return await _context.SubEntradas
                .Select(s => new SubEntradaDTO
                {
                    IdSubEnt = s.IdSubEnt,
                    IdEntPadre = s.IdEntPadre,
                    IdEntHijo = s.IdEntHijo
                })
                .ToListAsync();
        }

        public async Task<SubEntradaDTO> ObtenerPorIdAsync(int id)
        {
            var sub = await _context.SubEntradas.FindAsync(id);
            if (sub == null) return null;

            return new SubEntradaDTO
            {
                IdSubEnt = sub.IdSubEnt,
                IdEntPadre = sub.IdEntPadre,
                IdEntHijo = sub.IdEntHijo
            };
        }

        public async Task<SubEntradaDTO> CrearAsync(SubEntradaDTO dto)
        {
            var nueva = new SubEntrada
            {
                IdEntPadre = dto.IdEntPadre,
                IdEntHijo = dto.IdEntHijo
            };

            _context.SubEntradas.Add(nueva);
            await _context.SaveChangesAsync();

            dto.IdSubEnt = nueva.IdSubEnt;
            return dto;
        }
    }
}
