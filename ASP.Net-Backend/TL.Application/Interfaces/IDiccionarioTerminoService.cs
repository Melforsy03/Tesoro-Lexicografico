using TL.Application.DTOs;

namespace TL.Application.Interfaces
{
    public interface IDiccionarioTerminoService
    {
        Task<IEnumerable<DiccionarioTerminoDTO>> ObtenerTodosAsync();
        Task<DiccionarioTerminoDTO> ObtenerPorIdAsync(int id);
        Task<DiccionarioTerminoDTO> CrearAsync(DiccionarioTerminoDTO dto);
    }
}
