using TL.Application.ApplicationServices.DTOs;

namespace TL.Application.ApplicationServices.Interfaces
{
    public interface IDiccionarioService
    {
        Task<IEnumerable<DiccionarioDTO>> ObtenerTodosAsync();
        Task<DiccionarioDTO> ObtenerPorIdAsync(int id);
        Task<DiccionarioDTO> CrearAsync(DiccionarioDTO dto);
        Task<DiccionarioDTO> BorrarAsync(int Id);
    }
}
