using Microsoft.AspNetCore.Mvc;

namespace Supermercado.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
