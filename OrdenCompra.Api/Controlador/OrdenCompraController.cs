[ApiController]
[Route("api/[controller]")]

namespace crud2.OrdenCompra.Api.Controllers : ControllerBase
{
    private readonly IOrdenCompraService _service;

    public OrdenCompraController(IOrdenCompraService service)
        => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var orden = await _service.GetByIdAsync(id);
        return orden is null ? NotFound() : Ok(orden);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OrdenCompraDto dto)
    {
        var orden = new OrdenCompra(dto.ProveedorId, dto.MontoTotal, "Creada", dto.Comentarios);
        await _service.CreateAsync(orden);
        return CreatedAtAction(nameof(Get), new { id = orden.OrdenCompraId }, orden);
    }

    [HttpPut("{id}/approve")]
    public async Task<IActionResult> Approve(int id)
    {
        await _service.ApproveAsync(id);
        return NoContent();
    }

    [HttpPut("{id}/cancel")]
    public async Task<IActionResult> Cancel(int id)
    {
        await _service.CancelAsync(id);
        return NoContent();
    }
}
