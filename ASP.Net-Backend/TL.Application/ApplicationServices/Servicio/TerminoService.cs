using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TL.Application.ApplicationServices.DTOs;
using TL.Application.ApplicationServices.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure;

namespace TL.Application.ApplicationServices.Servicio
{
    public class TerminoService : ITerminoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TerminoService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TerminoDTO>> ObtenerTodosAsync()
        {
            var terminos = await _context.Terminos.ToListAsync();
            List<TerminoDTO> terminosDtos = new List<TerminoDTO>();

            for(int i = 0; i <  terminos.Count; i++)
            {
                var terminoDto = _mapper.Map<TerminoDTO>(terminos[i]);  
                terminosDtos.Add(terminoDto);
            }
            if (terminosDtos.Count == 0) return null;
            return terminosDtos;
        }

        public async Task<TerminoDTO> ObtenerPorIdAsync(int id)
        {
            var termino = await _context.Terminos.FindAsync(id);
            if (termino == null) return null;
            return _mapper.Map<TerminoDTO>(termino);
        }

        public async Task<TerminoDTO> CrearAsync(TerminoDTO dto)
        {
            if (dto == null) return null;
            var termino = _mapper.Map<Termino>(dto);

            await _context.Terminos.AddAsync(termino);
            await _context.SaveChangesAsync();

            return _mapper.Map<TerminoDTO>(termino);
        }

        public async Task<TerminoDTO> BorrarAsync(int Id)
        {
            var termino = await _context.Terminos.FindAsync(Id);
            if (termino == null) return null;
            var terminoDto = _mapper.Map<TerminoDTO>(termino);

            _context.Terminos.Remove(termino);
            await _context.SaveChangesAsync();

            return terminoDto;
        }
    }
}
