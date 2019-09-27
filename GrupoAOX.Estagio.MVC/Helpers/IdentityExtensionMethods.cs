using System;
using System.Security.Claims;
using System.Security.Principal;

namespace GrupoAOX.Estagio.MVC.Helpers
{
    public static class IdentityExtensionMethods
    {
        public static string GetUserName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Name);

            return (claim != null) ? claim.Value : string.Empty;
        }

        public static int GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.PrimarySid);

            return (claim != null) ? Int32.Parse(claim.Value) : 0;
        }

        public static string GetUserLogin(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.NameIdentifier);

            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserImage(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.UserData);

            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetEmail(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Email);

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}