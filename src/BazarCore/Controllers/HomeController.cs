using BazarCore.Models;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BazarCore.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IEventService _eventService;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IEventService eventService = null)
        {
            _logger = logger;
            _categoryService = categoryService;
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryResult = await _categoryService.GetAllActiveCategories();
            var upComeEventsResult = await _eventService.GetAllUpcomeEvents(1, 50);

            ViewBag.Categories = (categoryResult.Success) ? categoryResult.Data : new();
            ViewBag.UpComeEvents = (upComeEventsResult.Success) ? upComeEventsResult.Data : new();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}