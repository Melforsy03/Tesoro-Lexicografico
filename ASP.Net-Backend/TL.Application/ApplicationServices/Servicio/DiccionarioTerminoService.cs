using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TL.Application.ApplicationServices.DTOs;
using TL.Application.ApplicationServices.Interfaces;
using TL.Domain.Entidades;
using TL.Domain.Relaciones;
using TL.Infrastructure;

namespace TL.Application.ApplicationServices.Servicio
{
    public class DiccionarioTerminoService : IDiccionarioTerminoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public DiccionarioTerminoService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiccionarioTerminoDTO>> ObtenerTodosAsync()
        {
            var diccionarioTerminos = await _context.Editores.ToListAsync();
            List<DiccionarioTerminoDTO> diccionarioTerminoDto = new List<DiccionarioTerminoDTO>();
            for (int i = 0; i < diccionarioTerminos.Count(); i++)
            {
                var dicDto = _mapper.Map<DiccionarioTerminoDTO>(diccionarioTerminos[i]);
                diccionarioTerminoDto.Add(dicDto);
            }
            if (diccionarioTerminoDto.Count == 0) return null;
            return diccionarioTerminoDto;
        }

        public async Task<DiccionarioTerminoDTO> ObtenerPorIdAsync(int id)
        {
            var diccionarioTermino = await _context.Entradas.FindAsync(id);
            if (diccionarioTermino == null) return null;
            return _mapper.Map<DiccionarioTerminoDTO>(diccionarioTermino);
        }

        public async Task<DiccionarioTerminoDTO> CrearAsync(DiccionarioTerminoDTO dto)
        {
            if (dto == null) return null;

            var diccionarioTermino = _mapper.Map<DiccionarioTermino>(dto);

            await _context.Entradas.AddAsync(diccionarioTermino);
            await _context.SaveChangesAsync();

            return _mapper.Map<DiccionarioTerminoDTO>(diccionarioTermino);
        }

        public async Task<DiccionarioTerminoDTO> BorrarAsync(int Id)
        {
            var diccionarioTermino = await _context.Entradas.FindAsync(Id);
            if (diccionarioTermino == null) return null;
            var dicTerDto = _mapper.Map<DiccionarioTerminoDTO>(diccionarioTermino);
            _context.Entradas.Remove(diccionarioTermino);

            await _context.SaveChangesAsync();

            return dicTerDto;
        }
    }
}
