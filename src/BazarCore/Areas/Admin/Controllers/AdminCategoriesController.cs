using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarCore.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Route("categorias")]
    public class AdminCategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllActiveCategories();

            return View(result.Data);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
