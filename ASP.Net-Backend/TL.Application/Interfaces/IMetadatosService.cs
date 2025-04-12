using TL.Application.DTOs;

namespace TL.Application.Interfaces
{
    public interface IMetadatosService
    {
        Task<IEnumerable<MetadatosDTO>> ObtenerTodosAsync();
        Task<MetadatosDTO> ObtenerPorIdAsync(int id);
        Task<MetadatosDTO> CrearAsync(MetadatosDTO dto);
    }
}
