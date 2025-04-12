using TL.Application.DTOs;
using TL.Application.Enums;
using TL.Application.Interfaces;
using TL.Domain.Entidades;

namespace Tl.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> CrearUsuarioAsync(CrearUsuarioRequest request)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nombre = request.Nombre,
                Contrasena = Hashear(request.Contrasena),
                Rol = request.Rol
            };

            await _repo.AgregarAsync(usuario);
            return usuario.Id;
        }

        private string Hashear(string contrasena)
        {
            // Ejemplo simple, reemplazar con BCrypt o similar en producción
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(contrasena));
        }
    }
}
