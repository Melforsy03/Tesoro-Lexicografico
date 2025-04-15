using TL.Application.ApplicationServices.DTOs;

namespace TL.Application.ApplicationServices.Interfaces
{
    public interface ITerminoService
    {
        Task<IEnumerable<TerminoDTO>> ObtenerTodosAsync();
        Task<TerminoDTO> ObtenerPorIdAsync(int Id);
        Task<TerminoDTO> CrearAsync(TerminoDTO dto);
        Task<TerminoDTO> BorrarAsync(int Id);
    }
}
