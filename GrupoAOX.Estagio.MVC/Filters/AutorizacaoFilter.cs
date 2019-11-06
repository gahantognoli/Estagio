using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ClaimsAutorizeAttribute : AuthorizeAttribute
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var principal = filterContext.RequestContext.HttpContext.User as ClaimsPrincipal;

            if (!principal.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }

            var claimValue = ClaimValue.Split(',');

            if (!(principal.HasClaim(x => x.Type == ClaimType && claimValue.Any(v => v == x.Value))))
            {
                filterContext.Result = new RedirectResult("~/Error/AccessDenied");
            }
        }
    }
}