using System.Security.Claims;
using System.Security.Principal;

namespace BazarCore.Utils.Security
{
    public static class IdentityHelper
    {
        public static string GetEmail(this IIdentity identity)
        {
            return new ClaimsPrincipal(identity).Claims
                 .FirstOrDefault(x => x.Type == "email").Value;
        }
        public static string GetImage(this IIdentity identity)
        {
            return new ClaimsPrincipal(identity).Claims
                 .FirstOrDefault(x => x.Type == "image").Value;
        }
        public static string GetName(this IIdentity identity)
        {
            var name = new ClaimsPrincipal(identity).Claims
                 .FirstOrDefault(x => x.ValueType == "name").Value;
            return name;
        }
        public static string GetUserId(this IIdentity identity)
        {
            return new ClaimsPrincipal(identity).Claims
                 .FirstOrDefault(x => x.Type == "uid").Value;
        }
    }
}
