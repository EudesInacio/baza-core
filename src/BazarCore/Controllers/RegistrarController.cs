using BazarCore.Models.DTO;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BazarCore.Models.DTO.UserDTO;

namespace BazarCore.Controllers
{
    public class RegistrarController : Controller
    {
        IUserService _userService;

        public RegistrarController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost("registrar")]
        public async Task<IActionResult> Post(RegisterUserDTO user)
        {
            var result = await _userService.CreateUserAsync(user);
            if (result.Success)
            {

                return RedirectToAction("index", "entrar", new { mustVerifyEmail = true });
            }
            else
            {
                ViewBag.Result = result;
                ViewBag.User = user;
                return View("index");
            }
        }
    }
}
