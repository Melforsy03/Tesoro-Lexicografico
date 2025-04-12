using TL.Application.DTOs;

namespace TL.Application.Interfaces
{
    public interface IDiccionarioService
    {
        Task<IEnumerable<DiccionarioDTO>> ObtenerTodosAsync();
        Task<DiccionarioDTO> ObtenerPorIdAsync(int id);
        Task<DiccionarioDTO> CrearAsync(DiccionarioDTO dto);
    }
}
