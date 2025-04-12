using TL.Application.DTOs;

namespace TL.Application.Interfaces
{
    public interface ISubEntradaService
    {
        Task<IEnumerable<SubEntradaDTO>> ObtenerTodasAsync();
        Task<SubEntradaDTO> ObtenerPorIdAsync(int id);
        Task<SubEntradaDTO> CrearAsync(SubEntradaDTO dto);
    }
}
