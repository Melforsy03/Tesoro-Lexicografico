using TL.Application.DTOs;

namespace TL.Application.Interfaces
{
    public interface IAcepcionService
    {
        Task<IEnumerable<AcepcionDTO>> ObtenerTodasAsync();
        Task<AcepcionDTO> ObtenerPorIdAsync(int id);
        Task<AcepcionDTO> CrearAsync(AcepcionDTO dto);
    }
}
