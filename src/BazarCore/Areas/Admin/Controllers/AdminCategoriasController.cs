using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarCore.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Route("categorias")]
    public class AdminCategoriasController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoriasController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllActiveCategories();

            return View(result.Data);
        }
    }
}
