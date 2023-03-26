using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarCore.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Route("categorias")]
    public class AdminCategoriesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
