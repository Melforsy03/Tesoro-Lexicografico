using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TL.Application.ApplicationServices.DTOs;
using TL.Application.ApplicationServices.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure; // Ajusta si tu namespace de DbContext es otro

namespace TL.Application.ApplicationServices.Servicio
{
    public class AcepcionService : IAcepcionService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public AcepcionService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AcepcionDTO>> ObtenerTodasAsync()
        {
            var acepciones = await _context.Acepciones.ToListAsync();
            List<AcepcionDTO> acepcionesDto = new List<AcepcionDTO>();
            for(int i = 0; i < acepciones.Count(); i++)
            {
                var acepcionDto = _mapper.Map<AcepcionDTO>(acepciones[i]);
                acepcionesDto.Add(acepcionDto);
            }
            if (acepcionesDto.Count == 0) return null;
            return acepcionesDto;
  
        }

        public async Task<AcepcionDTO> ObtenerPorIdAsync(int id)
        {
            var acepcion = await _context.Acepciones.FindAsync(id);
            if (acepcion == null) return null;
            return _mapper.Map<AcepcionDTO>(acepcion);
             
        }

        public async Task<AcepcionDTO> CrearAsync(AcepcionDTO dto)
        {
            if (dto == null) return null;

            var acepcion = _mapper.Map<Acepcion>(dto);

            await _context.Acepciones.AddAsync(acepcion);
            await _context.SaveChangesAsync();

            return _mapper.Map<AcepcionDTO>(acepcion);
        }

        public async Task<AcepcionDTO> BorrarAsync(int Id)
        {
            var acepcion = await _context.Acepciones.FindAsync(Id);
            if (acepcion == null) return null;
            var acepcionDto = _mapper.Map<AcepcionDTO>(acepcion);
            _context.Acepciones.Remove(acepcion);

            await _context.SaveChangesAsync();

            return acepcionDto;
        }
    }
}
