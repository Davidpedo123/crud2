using crud2.OrdenCompra.Application.DTOs;
using crud2.OrdenCompra.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace crud2.OrdenCompra.Api.Controllers
{
    [ApiController]
    [Route("api/ordenes-compra")]
    [Produces("application/json")]
    public class OrdenCompraControllerAPI : ControllerBase
    {
        private readonly IServicioOrdenCompra _service;

        public OrdenCompraControllerAPI(IServicioOrdenCompra service)
        {
            _service = service;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenCompraDto>>> GetAll()
        {
            var ordenes = await _service.GetAllAsync();
            return Ok(ordenes);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenCompraDto>> GetById(int id)
        {
            var orden = await _service.GetByIdAsync(id);
            return orden is null ? NotFound() : Ok(orden);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrdenCompraDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrdenCompraDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(dto);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        
        [HttpPut("{id}/aprobar")]
        public async Task<IActionResult> AprobarOrden(int id)
        {
            var orden = await _service.GetByIdAsync(id);
            if (orden is null)
                return NotFound();

            orden.Estado = "Aprobada";
            await _service.UpdateAsync(orden);
            return NoContent();
        }

        
        [HttpPut("{id}/cancelar")]
        public async Task<IActionResult> CancelarOrden(int id)
        {
            var orden = await _service.GetByIdAsync(id);
            if (orden is null)
                return NotFound();

            orden.Estado = "Cancelada";
            await _service.UpdateAsync(orden);
            return NoContent();
        }
    }
}