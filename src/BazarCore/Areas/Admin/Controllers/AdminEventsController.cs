using BazarCore.Models.DTO;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Configuration;
using System.Web;

namespace BazarCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminEventsController : Controller
    {

        private readonly IEventService _eventService;
        private readonly ICategoryService _categoryService;

        [Parameter]
        public int EventId { get; set; }
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
                       

            //return RedirectToAction("index");

            var lEvents = await _eventService.GetAllEvents();

            return View("~/Areas/Admin/Views/AdminEvents/Index.cshtml", lEvents.Data);

            //return await Index(lEvents.Data);

            //return View();
        }

        public async Task<IActionResult> Remove(string eventId)
        {
                    
            bool bdeleteStatus = await _eventService.RemoveAsync(int.Parse(eventId));

            if (bdeleteStatus) {
                //TODO: ERROR HANDLING HERE           
            }

            else
            {
                //TODO: ERROR HANDLING HERE
            }

            var lEvents = await _eventService.GetAllEvents();

            return View("~/Areas/Admin/Views/AdminEvents/Index.cshtml", lEvents.Data);

        }
    }
}
