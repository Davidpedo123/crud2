using Microsoft.AspNetCore.Mvc;
using crud2.OrdenCompra.Application.Interfaces;
using crud2.OrdenCompra.Application.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace crud2.OrdenCompra.Web.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IProveedorService _service;

        public ProveedorController(IProveedorService service)
        {
            _service = service;
        }

        // GET: Proveedor
        public async Task<IActionResult> Index()
        {
            var proveedores = await _service.GetAllAsync();
            return View(proveedores);
        }

        // GET: Proveedor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var proveedor = await _service.GetByIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProveedorDto dto)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: Proveedor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var proveedor = await _service.GetByIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProveedorDto dto)
        {
            if (id != dto.ProveedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        // GET: Proveedor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _service.GetByIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}