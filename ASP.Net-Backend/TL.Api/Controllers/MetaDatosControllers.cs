using Microsoft.AspNetCore.Mvc;
using TL.Application.DTOs;
using TL.Application.Interfaces;

namespace TL.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetadatosController : ControllerBase
    {
        private readonly IMetadatosService _service;

        public MetadatosController(IMetadatosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var lista = await _service.ObtenerTodosAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var item = await _service.ObtenerPorIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] MetadatosDTO dto)
        {
            var creado = await _service.CrearAsync(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.IdMet }, creado);
        }
    }
}
