//using BazarCore.Services.Interfaces;
//using Microsoft.AspNetCore.Authentication.Cookies;

//namespace BazarCore.Utils.Security
//{
//    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
//    {
//        private readonly IUserService _userService;

//        public CustomCookieAuthenticationEvents(IUserService userService)
//        {
//            // Get the database from registered DI services.
//            _userService = userService;
//        }

//        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
//        {
//            var userPrincipal = context.Principal;

//            // Look for the LastChanged claim.
//            var uid = (from c in userPrincipal.Claims
//                       where c.Type == "uid"
//                       select c.Value).FirstOrDefault();
//            _userService();

//            if (_userService.HasChengedPermissions(Guid.Parse(uid)
//                , lastChanged))
//            {
//                context.RejectPrincipal();

//                //await context.HttpContext.SignOutAsync(
//                //    CookieAuthenticationDefaults.AuthenticationScheme);
//            }
//        }
//    }
//}
