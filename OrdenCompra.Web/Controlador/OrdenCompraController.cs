using crud2.OrdenCompra.Application.DTOs;
using crud2.OrdenCompra.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace crud2.OrdenCompra.Web.Controllers
{
    public class OrdenCompraController : Controller
    {
        private readonly IServicioOrdenCompra _service;
        private readonly IProveedorService _proveedorService;

        public OrdenCompraController(
            IServicioOrdenCompra service,
            IProveedorService proveedorService)
        {
            _service = service;
            _proveedorService = proveedorService;
        }

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

        public async Task<IActionResult> Create()
        {
            var proveedores = await _proveedorService.GetAllAsync();
            ViewBag.Proveedores = new SelectList(proveedores, "ProveedorId", "Nombre");
            return View(new OrdenCompraDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdenCompraDto dto)
        {
            if (!ModelState.IsValid)
            {
                var proveedores = await _proveedorService.GetAllAsync();
                ViewBag.Proveedores = new SelectList(proveedores, "ProveedorId", "Nombre");
                return View(dto);
            }

            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var orden = await _service.GetByIdAsync(id);
            if (orden is null) return NotFound();

            var proveedores = await _proveedorService.GetAllAsync();
            ViewBag.Proveedores = new SelectList(proveedores, "ProveedorId", "Nombre", orden.ProveedorId);
            
            return View(orden);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, OrdenCompraDto dto)
        {
            if (id != dto.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                var proveedores = await _proveedorService.GetAllAsync();
                ViewBag.Proveedores = new SelectList(proveedores, "ProveedorId", "Nombre", dto.ProveedorId);
                return View(dto);
            }

            await _service.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var orden = await _service.GetByIdAsync(id);
            if (orden is null) return NotFound();
            return View(orden);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}