using TL.Application.DTOs;

namespace TL.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Guid> CrearUsuarioAsync(CrearUsuarioRequest request);
    }
}
