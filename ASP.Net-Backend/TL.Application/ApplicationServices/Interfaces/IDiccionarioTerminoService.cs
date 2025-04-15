using TL.Application.ApplicationServices.DTOs;

namespace TL.Application.ApplicationServices.Interfaces
{
    public interface IDiccionarioTerminoService
    {
        Task<IEnumerable<DiccionarioTerminoDTO>> ObtenerTodosAsync();
        Task<DiccionarioTerminoDTO> ObtenerPorIdAsync(int Id);
        Task<DiccionarioTerminoDTO> CrearAsync(DiccionarioTerminoDTO dto);
        Task<DiccionarioTerminoDTO> BorrarAsync(int Id);
    }
}
