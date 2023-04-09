using BazarCore.Services;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BazarCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrganizersController : Controller
    {
        private readonly IOrganizerService _organizerService;

        public AdminOrganizersController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        public async Task<IActionResult >Index()
        {
            var result = await _organizerService.GetAllOrganizers(1, 60);

            return View(result.Data);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
