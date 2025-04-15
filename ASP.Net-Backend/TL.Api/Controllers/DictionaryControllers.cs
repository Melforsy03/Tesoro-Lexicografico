using Microsoft.AspNetCore.Mvc;
using TL.Application.ApplicationServices.DTOs;
using TL.Application.ApplicationServices.Interfaces;

namespace TL.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiccionarioController : ControllerBase
    {
        private readonly IDiccionarioService _service;

        public DiccionarioController(IDiccionarioService service)
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
        public async Task<IActionResult> Crear([FromBody] DiccionarioDTO dto)
        {
            var creado = await _service.CrearAsync(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.IdDic }, creado);
        }
    }
}
