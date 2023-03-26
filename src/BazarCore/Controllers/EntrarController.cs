using BazarCore.Services;
using BazarCore.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static BazarCore.Models.DTO.UserDTO;

namespace BazarCore.Controllers
{
    public class EntrarController : Controller
    {
        private readonly IUserService _userService;
        public EntrarController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index(bool? mustVerifyEmail = false, bool? loginfailed = false)
        {
            ViewBag.MustVerifyEmail = mustVerifyEmail;
            ViewBag.Loginfailed = loginfailed;
            return View();
        }
        [HttpPost("entrar")]
        public async Task<IActionResult> Entrar(UserWebLoginDTO dto)
        {
            var resultLogin = await _userService.Login(dto);
            if (resultLogin.Success)
            {
                var user = resultLogin.Data;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, dto.Username),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim("uid", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };
                var identity = new System.Security.Claims.ClaimsIdentity(
                     claims, CookieAuthenticationDefaults.AuthenticationScheme);


                var principal = new System.Security.Claims.ClaimsPrincipal(identity);

                await HttpContext.SignOutAsync();


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                    principal, new AuthenticationProperties { IsPersistent = true });

                return RedirectToAction("index", "home");
            }
            else
            {
                return RedirectToAction("index", "entrar", new { loginfailed = true });
            }
        }


    }
}
