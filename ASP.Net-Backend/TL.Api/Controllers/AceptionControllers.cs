using Microsoft.AspNetCore.Mvc;
using TL.Application.DTOs;
using TL.Application.Interfaces;

namespace TL.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcepcionController : ControllerBase
    {
        private readonly IAcepcionService _service;

        public AcepcionController(IAcepcionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var lista = await _service.ObtenerTodasAsync();
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
        public async Task<IActionResult> Crear([FromBody] AcepcionDTO dto)
        {
            var creado = await _service.CrearAsync(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.IdAc }, creado);
        }
    }
}
