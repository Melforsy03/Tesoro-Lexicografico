using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TL.Application.ApplicationServices.DTOs;
using TL.Application.ApplicationServices.Interfaces;
using TL.Domain.Relaciones;
using TL.Infrastructure;

namespace TL.Application.ApplicationServices.Servicio
{
    public class SubEntradaService : ISubEntradaService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public SubEntradaService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubEntradaDTO>> ObtenerTodasAsync()
        {
            var subEntradas = await _context.SubEntradas.ToListAsync();
            List<SubEntradaDTO> subEntradaDTOs = new List<SubEntradaDTO>();

            for(int i = 0; i < subEntradas.Count; i++)
            {
                var subEntradaDto = _mapper.Map<SubEntradaDTO>(subEntradas[i]);
                subEntradaDTOs.Add(subEntradaDto);
            }

            if (subEntradaDTOs.Count() == 0) return null;

            return subEntradaDTOs;
        }

        public async Task<SubEntradaDTO> ObtenerPorIdAsync(int id)
        {
            var subEntrada = await _context.SubEntradas.FindAsync(id);
            if (subEntrada == null) return null;

            return _mapper.Map<SubEntradaDTO>(subEntrada);
        }

        public async Task<SubEntradaDTO> CrearAsync(SubEntradaDTO dto)
        {
            if (dto == null) return null;
            var subEntrada = _mapper.Map<SubEntrada>(dto);
            
            await _context.SubEntradas.AddAsync(subEntrada);
            await _context.SaveChangesAsync();

            return _mapper.Map<SubEntradaDTO>(subEntrada);
        }

        public async Task<SubEntradaDTO> BorrarAsync(int Id)
        {
            var subEntrada = await _context.SubEntradas.FindAsync(Id);
            if (subEntrada == null) return null;
            var subEntradaDto = _mapper.Map<SubEntradaDTO>(subEntrada);

            _context.SubEntradas.Remove(subEntrada);
            await _context.SaveChangesAsync();

            return subEntradaDto;
        }
    }
}
