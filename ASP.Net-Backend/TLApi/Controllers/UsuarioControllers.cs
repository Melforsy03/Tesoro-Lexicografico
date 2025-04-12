using Microsoft.AspNetCore.Mvc;
using TL.Application.DTOs;
using TL.Application.Interfaces;

namespace TL.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioRequest request)
        {
            var id = await _usuarioService.CrearUsuarioAsync(request);
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioPorId(Guid id)
        {
            // Esto se implementará después con el método del repositorio
            return Ok();
        }
    }
}
