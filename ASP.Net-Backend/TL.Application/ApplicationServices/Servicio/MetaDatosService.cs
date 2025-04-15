using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TL.Application.ApplicationServices.DTOs;
using TL.Application.ApplicationServices.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure;

namespace TL.Application.ApplicationServices.Servicio
{
    public class MetadatosService : IMetadatosService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MetadatosService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MetadatosDTO>> ObtenerTodosAsync()
        {
            var metaDatos = await _context.Metadatos.ToListAsync();
            List<MetadatosDTO> metadatosDTOs = new List<MetadatosDTO>();

            for(int i = 0; i < metaDatos.Count; i++)
            {
                var metaDato = _mapper.Map<MetadatosDTO>(metaDatos[i]);
                metadatosDTOs.Add(metaDato);
            }
            if (metadatosDTOs.Count == 0) return null;
            return metadatosDTOs;
        }

        public async Task<MetadatosDTO> ObtenerPorIdAsync(int id)
        {
            var metaDato = await _context.Metadatos.FindAsync(id);
            if (metaDato == null) return null;
            return _mapper.Map<MetadatosDTO>(metaDato);
        }

        public async Task<MetadatosDTO> CrearAsync(MetadatosDTO dto)
        {
            if (dto == null) return null;

            var metaDato = _mapper.Map<Metadatos>(dto);
            await _context.Metadatos.AddAsync(metaDato);
            await _context.SaveChangesAsync();

            return _mapper.Map<MetadatosDTO>(metaDato);
        }

        public async Task<MetadatosDTO> BorrarAsync(int Id)
        {
            var metaDato = await _context.Metadatos.FindAsync(Id);
            if (metaDato == null) return null;
            var metaDatoDto = _mapper.Map<MetadatosDTO>(metaDato);

            _context.Metadatos.Remove(metaDato);
            await _context.SaveChangesAsync();

            return metaDatoDto;
        }
    }
}
