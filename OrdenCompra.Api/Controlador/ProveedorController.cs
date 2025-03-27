using crud2.OrdenCompra.Application.DTOs;
using crud2.OrdenCompra.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace crud2.OrdenCompra.Api.Controllers
{
    [ApiController]
    [Route("api/proveedores")]
    [Produces("application/json")]
    public class ProveedorControllerAPI : ControllerBase
    {
        private readonly IProveedorService _service;

        public ProveedorControllerAPI(IProveedorService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> GetAll()
        {
            var proveedores = await _service.GetAllAsync();
            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorDto>> GetById(int id)
        {
            var proveedor = await _service.GetByIdAsync(id);
            return proveedor is null ? NotFound() : Ok(proveedor);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProveedorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.ProveedorId }, dto);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProveedorDto dto)
        {
            if (id != dto.ProveedorId)
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
    }
}