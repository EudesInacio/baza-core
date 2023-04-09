using BazarCore.Models.DTO;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BazarCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminEventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ICategoryService _categoryService;
        public AdminEventsController(IEventService eventService, ICategoryService categoryService)
        {
            _eventService = eventService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _eventService.GetAllEvents();
            return View(result.Data);
        }

        public async Task<IActionResult> Create()
        {
               ViewBag.Categories = (await _categoryService.GetAllActiveCategories()).Data; 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddEventDTO addEvent)
        {
            var result = await _eventService.AddAsync(addEvent);
         
            return RedirectToAction("index");
        }
    }
}
