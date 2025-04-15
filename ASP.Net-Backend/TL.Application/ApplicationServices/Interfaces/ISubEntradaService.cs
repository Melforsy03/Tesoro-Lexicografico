using TL.Application.ApplicationServices.DTOs;

namespace TL.Application.ApplicationServices.Interfaces
{
    public interface ISubEntradaService
    {
        Task<IEnumerable<SubEntradaDTO>> ObtenerTodasAsync();
        Task<SubEntradaDTO> ObtenerPorIdAsync(int id);
        Task<SubEntradaDTO> CrearAsync(SubEntradaDTO dto);
        Task<SubEntradaDTO> BorrarAsync(int Id);
    }
}
