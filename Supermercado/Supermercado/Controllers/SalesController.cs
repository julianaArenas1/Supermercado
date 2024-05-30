using Microsoft.AspNetCore.Mvc;

namespace Supermercado.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
