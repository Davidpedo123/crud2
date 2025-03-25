using Microsoft.AspNetCore.Mvc;

namespace crud2.OrdenCompra.Web.Controlador;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}
