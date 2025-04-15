using TL.Application.ApplicationServices.DTOs;

namespace TL.Application.ApplicationServices.Interfaces
{
    public interface IMetadatosService
    {
        Task<IEnumerable<MetadatosDTO>> ObtenerTodosAsync();
        Task<MetadatosDTO> ObtenerPorIdAsync(int Id);
        Task<MetadatosDTO> CrearAsync(MetadatosDTO dto);
        Task<MetadatosDTO> BorrarAsync(int Id);
    }
}
