using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Helpers
{
    public static class PermissonHelperExtensionMethods
    {
        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName,
            string claimValue)
        {
            return ValidatePermission(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static bool IfClaim(this WebViewPage page, string claimName, string claimValue)
        {
            return ValidatePermission(claimName, claimValue);
        }

        private static bool ValidatePermission(string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role && c.Value == claimValue);
            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}