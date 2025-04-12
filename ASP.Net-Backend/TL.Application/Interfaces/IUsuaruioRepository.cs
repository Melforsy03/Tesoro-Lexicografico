using TL.Domain.Entidades;

namespace TL.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AgregarAsync(Usuario usuario);
        Task<Usuario> ObtenerPorIdAsync(Guid id);
        // Puedes agregar más métodos aquí
    }
}
