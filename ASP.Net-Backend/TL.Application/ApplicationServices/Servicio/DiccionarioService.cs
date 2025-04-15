using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TL.Application.ApplicationServices.DTOs;
using TL.Application.ApplicationServices.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure;

namespace TL.Application.ApplicationServices.Servicio
{
    public class DiccionarioService : IDiccionarioService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public DiccionarioService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiccionarioDTO>> ObtenerTodosAsync()
        {
            var diccionarios = await _context.Acepciones.ToListAsync();
            List<DiccionarioDTO> diccionariosDto = new List<DiccionarioDTO>();
            for (int i = 0; i < diccionarios.Count(); i++)
            {
                var dicDto = _mapper.Map<DiccionarioDTO>(diccionarios[i]);
                diccionariosDto.Add(dicDto);
            }
            if (diccionariosDto.Count == 0) return null;
            return diccionariosDto;
        }

        public async Task<DiccionarioDTO> ObtenerPorIdAsync(int id)
        {
            var diccionario = await _context.Diccionarios.FindAsync(id);
            if (diccionario == null) return null;
            return _mapper.Map<DiccionarioDTO>(diccionario);
        }

        public async Task<DiccionarioDTO> CrearAsync(DiccionarioDTO dto)
        {
            if (dto == null) return null;

            var diccionario = _mapper.Map<Diccionario>(dto);

            await _context.Diccionarios.AddAsync(diccionario);
            await _context.SaveChangesAsync();

            return _mapper.Map<DiccionarioDTO>(diccionario);
        }

        public async Task<DiccionarioDTO> BorrarAsync(int Id)
        {
            var diccionario = await _context.Diccionarios.FindAsync(Id);
            if (diccionario == null) return null;
            var dicDto = _mapper.Map<DiccionarioDTO>(diccionario);
            _context.Diccionarios.Remove(diccionario);

            await _context.SaveChangesAsync();

            return dicDto;
        }
    }
}
