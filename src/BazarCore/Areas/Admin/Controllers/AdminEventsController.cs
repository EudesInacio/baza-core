using BazarCore.Models.DTO;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BazarCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminEventsController : Controller
    {
        private readonly IEventService _eventService;
        public AdminEventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _eventService.GetAllEvents();
            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddEventDTO addEvent)
        {
            var result = await _eventService.AddAsync(addEvent);
            return View();
        }
    }
}
