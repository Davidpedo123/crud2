using Microsoft.AspNetCore.Mvc;
using crud2.Data;
using crud2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace crud2.Controllers
{
    [Route("Instituciones")]
    public class InstitucionesController : Controller
    {
        private readonly InstitucionesContext _context;

        public InstitucionesController(InstitucionesContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var instituciones = await _context.Instituciones.ToListAsync();
            return View("~/Views/Home/Index.cshtml", instituciones);
        }

        
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var institucion = await _context.Instituciones.FirstOrDefaultAsync(i => i.Id == id);
            if (institucion == null)
            {
                return NotFound();
            }
            return View("~/Views/Home/Details.cshtml", institucion);
        }

        
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View("~/Views/Home/Create.cshtml");
        }

        
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Institucion institucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Home/Create.cshtml", institucion);
        }

        
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var institucion = await _context.Instituciones.FindAsync(id);
            if (institucion == null)
            {
                return NotFound();
            }
            return View("~/Views/Home/Edit.cshtml", institucion);
        }

        
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Institucion institucion)
        {
            if (id != institucion.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitucionExists(institucion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Home/Edit.cshtml", institucion);
        }

        
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var institucion = await _context.Instituciones.FirstOrDefaultAsync(i => i.Id == id);
            if (institucion == null)
            {
                return NotFound();
            }
            return View("~/Views/Home/Delete.cshtml", institucion);
        }

        
        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institucion = await _context.Instituciones.FindAsync(id);
            if (institucion == null)
            {
                return NotFound();
            }
            _context.Instituciones.Remove(institucion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitucionExists(int id)
        {
            return _context.Instituciones.Any(e => e.Id == id);
        }
    }
}
