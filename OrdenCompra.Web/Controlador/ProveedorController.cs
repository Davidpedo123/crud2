using Microsoft.AspNetCore.Mvc;
using crud2.OrdenCompra.Application.Interfaces;
using crud2.OrdenCompra.Domain.Entidades;

namespace crud2.OrdenCompra.Web.Controlador;


[ApiController]
[Route("api/[controller]")]
public class ProveedorController : ControllerBase
{
    private readonly IProveedorService _service;

    public ProveedorController(IProveedorService service)
        => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var proveedor = await _service.GetProveedorAsync(id);
        return proveedor is null ? NotFound() : Ok(proveedor);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProveedorDto dto)
    {
        var proveedor = new Proveedor(dto.Nombre, dto.Contacto, dto.Telefono, dto.Email, dto.Direccion);
        await _service.CreateProveedorAsync(proveedor);
        return CreatedAtAction(nameof(Get), new { id = proveedor.ProveedorId }, proveedor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProveedorDto dto)
    {
        var proveedor = await _service.GetProveedorAsync(id);
        if (proveedor is null) return NotFound();

        proveedor.Update(dto.Nombre, dto.Contacto, dto.Telefono, dto.Email, dto.Direccion);
        await _service.UpdateProveedorAsync(proveedor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteProveedorAsync(id);
        return NoContent();
    }
}
