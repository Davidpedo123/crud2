// OrdenCompra.Web/Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace crud2.OrdenCompra.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}