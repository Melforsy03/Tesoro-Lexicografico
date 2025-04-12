using Microsoft.EntityFrameworkCore;
using TL.Application.DTOs;
using TL.Application.Interfaces;
using TL.Domain.Entidades;
using TL.Infrastructure;

namespace TL.Application.Services
{
    public class MetadatosService : IMetadatosService
    {
        private readonly Context _context;

        public MetadatosService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MetadatosDTO>> ObtenerTodosAsync()
        {
            return await _context.Metadatos
                .Select(m => new MetadatosDTO
                {
                    IdMet = m.IdMet,
                    IdDic = m.IdDic,
                    Titulo = m.Titulo,
                    TituloCompleto = m.TituloCompleto,
                    Autor = m.Autor,
                    FechaOriginal = m.FechaOriginal,
                    Siglo = m.Siglo,
                    LugarDePublicacion = m.LugarDePublicacion,
                    Publicador = m.Publicador,
                    FechaDePublicacion = m.FechaDePublicacion,
                    Edicion = m.Edicion,
                    NombreDeFuente = m.NombreDeFuente,
                    FuenteURL = m.FuenteURL,
                    Pais = m.Pais,
                    CodigoDePais = m.CodigoDePais,
                    Remarks = m.Remarks,
                    NombreDeProyecto = m.NombreDeProyecto,
                    Transcriptor = m.Transcriptor,
                    FechaDeTranscripcion = m.FechaDeTranscripcion,
                    Revisor = m.Revisor,
                    FechaDeRevision = m.FechaDeRevision,
                    NombreDePrologo = m.NombreDePrologo,
                    PrologoURL = m.PrologoURL
                })
                .ToListAsync();
        }

        public async Task<MetadatosDTO> ObtenerPorIdAsync(int id)
        {
            var meta = await _context.Metadatos.FindAsync(id);
            if (meta == null) return null;

            return new MetadatosDTO
            {
                IdMet = meta.IdMet,
                IdDic = meta.IdDic,
                Titulo = meta.Titulo,
                TituloCompleto = meta.TituloCompleto,
                Autor = meta.Autor,
                FechaOriginal = meta.FechaOriginal,
                Siglo = meta.Siglo,
                LugarDePublicacion = meta.LugarDePublicacion,
                Publicador = meta.Publicador,
                FechaDePublicacion = meta.FechaDePublicacion,
                Edicion = meta.Edicion,
                NombreDeFuente = meta.NombreDeFuente,
                FuenteURL = meta.FuenteURL,
                Pais = meta.Pais,
                CodigoDePais = meta.CodigoDePais,
                Remarks = meta.Remarks,
                NombreDeProyecto = meta.NombreDeProyecto,
                Transcriptor = meta.Transcriptor,
                FechaDeTranscripcion = meta.FechaDeTranscripcion,
                Revisor = meta.Revisor,
                FechaDeRevision = meta.FechaDeRevision,
                NombreDePrologo = meta.NombreDePrologo,
                PrologoURL = meta.PrologoURL
            };
        }

        public async Task<MetadatosDTO> CrearAsync(MetadatosDTO dto)
        {
            var nuevo = new Metadatos
            {
                IdDic = dto.IdDic,
                Titulo = dto.Titulo,
                TituloCompleto = dto.TituloCompleto,
                Autor = dto.Autor,
                FechaOriginal = dto.FechaOriginal,
                Siglo = dto.Siglo,
                LugarDePublicacion = dto.LugarDePublicacion,
                Publicador = dto.Publicador,
                FechaDePublicacion = dto.FechaDePublicacion,
                Edicion = dto.Edicion,
                NombreDeFuente = dto.NombreDeFuente,
                FuenteURL = dto.FuenteURL,
                Pais = dto.Pais,
                CodigoDePais = dto.CodigoDePais,
                Remarks = dto.Remarks,
                NombreDeProyecto = dto.NombreDeProyecto,
                Transcriptor = dto.Transcriptor,
                FechaDeTranscripcion = dto.FechaDeTranscripcion,
                Revisor = dto.Revisor,
                FechaDeRevision = dto.FechaDeRevision,
                NombreDePrologo = dto.NombreDePrologo,
                PrologoURL = dto.PrologoURL
            };

            _context.Metadatos.Add(nuevo);
            await _context.SaveChangesAsync();

            dto.IdMet = nuevo.IdMet;
            return dto;
        }
    }
}
