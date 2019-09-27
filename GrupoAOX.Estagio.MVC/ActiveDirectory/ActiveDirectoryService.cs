using GrupoAOX.Estagio.Application.Interfaces;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace GrupoAOX.Estagio.MVC.ActiveDirectory
{
    public class ActiveDirectoryService
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IUsuarioAppServices _usuarioAppService;

        public ActiveDirectoryService(IAuthenticationManager authenticationManager,
            IUsuarioAppServices usuarioAppService)
        {
            _authenticationManager = authenticationManager;
            _usuarioAppService = usuarioAppService;
        }

        public AuthenticationResult SignIn(string username, string password)
        {
            //ContextType authenticationType = ContextType.Domain;
            //PrincipalContext principalContext = new PrincipalContext(authenticationType);
            //bool isAuthenticated = false;

            //UserPrincipal userPrincipal = new UserPrincipal(principalContext);
            //userPrincipal.SamAccountName = username;

            //var searcher = new PrincipalSearcher(userPrincipal);

            //try
            //{
            //    userPrincipal = searcher.FindOne() as UserPrincipal;
            //    if (userPrincipal != null)
            //    {
            //        isAuthenticated = principalContext.ValidateCredentials(username, password, ContextOptions.Negotiate);
            //    }

            //}
            //catch (Exception e)
            //{
            //    isAuthenticated = false;
            //    userPrincipal = null;
            //}

            //if (!isAuthenticated || userPrincipal == null)
            //{
            //    return new AuthenticationResult("Usuário ou senha inválido");
            //}

            //if (userPrincipal.IsAccountLockedOut())
            //{
            //    return new AuthenticationResult("Sua conta está bloqueada.");
            //}

            //if (userPrincipal.Enabled.HasValue && userPrincipal.Enabled.Value == false)
            //{
            //    return new AuthenticationResult("Sua conta está desativada");
            //}

            //ClaimsIdentity identity = CreateIdentity(userPrincipal);

            ClaimsIdentity identity = new ClaimsIdentity("ActiveDirectoryAuthentication", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Active Directory"));
            identity.AddClaim(new Claim(ClaimTypes.Name, "Gabriel Antognoli"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "gantognoli"));
            identity.AddClaim(new Claim(ClaimTypes.Email, "gabriel_antognoli@hotmail.com"));


            var usuario = _usuarioAppService.ObterPorLogin("gantognoli");

            foreach (var permissao in usuario.Permissoes)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, permissao.Sigla));
            }

            identity.AddClaim(new Claim(ClaimTypes.PrimarySid, usuario.UsuarioId.ToString()));

            if (usuario.CaminhoImg == null)
            {
                string imgDefault = "~/images/profile/default.png";
                identity.AddClaim(new Claim(ClaimTypes.UserData, imgDefault));
            }
            else
            {
                identity.AddClaim(new Claim(ClaimTypes.UserData, usuario.CaminhoImg));
            }

            _authenticationManager.SignOut("ActiveDirectoryAuthentication");
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);

            return new AuthenticationResult();
        }

        private ClaimsIdentity CreateIdentity(UserPrincipal userPrincipal)
        {
            ClaimsIdentity identity = new ClaimsIdentity("ActiveDirectoryAuthentication", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Active Directory"));
            identity.AddClaim(new Claim(ClaimTypes.Name, userPrincipal.Name));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userPrincipal.SamAccountName));

            if (!string.IsNullOrEmpty(userPrincipal.EmailAddress))
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, userPrincipal.EmailAddress));
            }

            var usuario = _usuarioAppService.ObterPorLogin(userPrincipal.SamAccountName);

            foreach (var permissao in usuario.Permissoes)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, permissao.Sigla));
            }

            identity.AddClaim(new Claim(ClaimTypes.PrimarySid, usuario.UsuarioId.ToString()));

            if (usuario.CaminhoImg == null)
            {
                string imgDefault = "~/Images/ProfileImages/default-img.png";
                identity.AddClaim(new Claim(ClaimTypes.UserData, imgDefault));
            }
            else
            {
                identity.AddClaim(new Claim(ClaimTypes.UserData, usuario.CaminhoImg));
            }

            return identity;
        }
    }
}