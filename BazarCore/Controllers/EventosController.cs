using BazarCore.Models;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace BazarCore.Controllers
{
    public class EventosController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IEventService _eventService;

        public EventosController(ICategoryService categoryService, IEventService eventService)
        {
            _categoryService = categoryService;
            _eventService = eventService;
        }
        public async Task<IActionResult> Index([FromQuery] SearchEvents? search = null)
        {
            var categoryResult = await _categoryService.GetAllActiveCategories();
            var eventsResult = await _eventService.GetAllActiveEvents(search, 1, 50);


            ViewBag.Categories = (categoryResult.Success) ? categoryResult.Data : new();
            ViewBag.Events = (eventsResult.Success) ? eventsResult.Data : new();
            ViewBag.SearchEvents = search;

            return View();
        }
        public async Task<IActionResult> Detalhes([FromRoute] int Id)
        {
            var resultService = await _eventService.GetEventDetails(Id);

            return View((resultService.Success) ? resultService.Data : null);
        }
    }
}
