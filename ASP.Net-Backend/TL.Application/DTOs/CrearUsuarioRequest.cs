using TL.Application.Enums;

namespace TL.Application.DTOs
{
    public class CrearUsuarioRequest
    {
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public RolUsuario Rol { get; set; }
    }
}
