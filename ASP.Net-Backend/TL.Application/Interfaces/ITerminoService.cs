using TL.Application.DTOs;

namespace TL.Application.Interfaces
{
    public interface ITerminoService
    {
        Task<IEnumerable<TerminoDTO>> ObtenerTodosAsync();
        Task<TerminoDTO> ObtenerPorIdAsync(int id);
        Task<TerminoDTO> CrearAsync(TerminoDTO dto);
    }
}
