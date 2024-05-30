using Microsoft.AspNetCore.Mvc;

namespace Supermercado.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
