using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Security.Claims;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(GrupoAOX.Estagio.MVC.App_Start.Startup))]

namespace GrupoAOX.Estagio.MVC.App_Start
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ActiveDirectoryAuthentication",
                LoginPath = new PathString("/Login"),
                Provider = new CookieAuthenticationProvider(),
                CookieName = "ActiveDirectoryCookie",
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromHours(4),
                LogoutPath = new PathString("/Logoff"),
                CookieSecure = CookieSecureOption.SameAsRequest,
                SlidingExpiration = true
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}
