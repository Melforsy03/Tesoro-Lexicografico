using TL.Application.ApplicationServices.DTOs;

namespace TL.Application.ApplicationServices.Interfaces
{
    public interface IAcepcionService
    {
        Task<IEnumerable<AcepcionDTO>> ObtenerTodasAsync();
        Task<AcepcionDTO> ObtenerPorIdAsync(int Id);
        Task<AcepcionDTO> CrearAsync(AcepcionDTO Dto);
        Task<AcepcionDTO> BorrarAsync(int Id);
    }
}
