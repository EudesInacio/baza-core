using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarCore.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Route("categorias")]
    public class AdminCategoriasController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
