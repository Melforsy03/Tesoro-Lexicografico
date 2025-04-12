using Microsoft.EntityFrameworkCore;
using TL.Application.DTOs;
using TL.Application.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure; // Ajusta si tu namespace de DbContext es otro

namespace TL.Application.Services
{
    public class AcepcionService : IAcepcionService
    {
        private readonly Context _context;

        public AcepcionService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AcepcionDTO>> ObtenerTodasAsync()
        {
            return await _context.Acepciones
                .Select(a => MapToDTO(a))
                .ToListAsync();
        }

        public async Task<AcepcionDTO> ObtenerPorIdAsync(int id)
        {
            var ac = await _context.Acepciones.FindAsync(id);
            return ac == null ? null : MapToDTO(ac);
        }

        public async Task<AcepcionDTO> CrearAsync(AcepcionDTO dto)
        {
            var nueva = new Acepcion
            {
                IdEnt = dto.IdEnt,
                NumDef = dto.NumDef,
                ClasePal = dto.ClasePal,
                Pais = dto.Pais,
                Etim = dto.Etim,
                ClaseSem = dto.ClaseSem,
                Def = dto.Def
            };

            _context.Acepciones.Add(nueva);
            await _context.SaveChangesAsync();

            return MapToDTO(nueva);
        }

        private AcepcionDTO MapToDTO(Acepcion a) =>
            new()
            {
                IdAc = a.IdAc,
                IdEnt = a.IdEnt,
                NumDef = a.NumDef,
                ClasePal = a.ClasePal,
                Pais = a.Pais,
                Etim = a.Etim,
                ClaseSem = a.ClaseSem,
                Def = a.Def
            };
    }
}
