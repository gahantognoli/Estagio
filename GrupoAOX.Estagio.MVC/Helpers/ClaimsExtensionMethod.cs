using GrupoAOX.Estagio.Application.Interfaces;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace GrupoAOX.Estagio.MVC.Helpers
{
    public static class ClaimsExtensionMethod
    {
        public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == key);
            return claim.Value;
        }

        public static void RemoveClaims(IEnumerable<Claim> claims, ClaimsIdentity identity)
        {
            foreach (var claim in claims)
            {
                identity.RemoveClaim(claim);
            }
        }

        public static void UpdateImageClaim(this IPrincipal currentPrincipal,
            int id,
            IUsuarioAppServices usuarioAppService)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return;

            identity.RemoveClaim(identity.FindFirst(c => c.Type == ClaimTypes.UserData));

            var usuario = usuarioAppService.ObterPorId(id);

            if (usuario.CaminhoImg == null)
            {
                string imgDefault = "~/Images/ProfileImages/default-img.png";
                identity.AddClaim(new Claim(ClaimTypes.UserData, imgDefault));
            }
            else
            {
                identity.AddClaim(new Claim(ClaimTypes.UserData, usuario.CaminhoImg));
            }

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity), new AuthenticationProperties() { IsPersistent = true });
        }
    }
}