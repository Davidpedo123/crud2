using Microsoft.AspNetCore.Mvc;
using crud2.OrdenCompra.Application.Interfaces;
using crud2.OrdenCompra.Domain.Entidades;

namespace crud2.OrdenCompra.Web.Controllers
{
    public class OrdenCompraController : Controller
    {
        private readonly IServicioOrdenCompra _service;

        public OrdenCompraController(IServicioOrdenCompra service)
            => _service = service;

        public async Task<IActionResult> Index()
        {
            var ordenes = await _service.GetAllAsync();
            return View(ordenes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var orden = await _service.GetByIdAsync(id);
            if (orden is null) return NotFound();
            return View(orden);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(OrdenCompraDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var orden = new crud2.OrdenCompra.Domain.Entidades.OrdenCompra(dto.ProveedorId, dto.MontoTotal, "Creada", dto.Comentarios);


           
            await _service.CreateAsync(orden);
            return RedirectToAction(nameof(Index));
        }
    }
}
