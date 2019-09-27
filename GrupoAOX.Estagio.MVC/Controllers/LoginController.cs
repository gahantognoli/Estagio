using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.MVC.ActiveDirectory;
using GrupoAOX.Estagio.MVC.Models;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioAppServices _usuarioAppService;

        public LoginController(IUsuarioAppServices usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                UrlRetorno = returnUrl
            };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuarioBD = _usuarioAppService.ObterPorLogin(model.Username);
            if (usuarioBD != null)
            {
                IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                var authService = new ActiveDirectoryService(authenticationManager, _usuarioAppService);

                var authenticationResult = authService.SignIn(model.Username, model.Password);

                if (authenticationResult.IsSuccess)
                {
                    if (!string.IsNullOrWhiteSpace(model.UrlRetorno) || Url.IsLocalUrl(model.UrlRetorno))
                        return Redirect(model.UrlRetorno);
                    else
                        return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Erro", authenticationResult.ErrorMessage);
            }
            else
            {
                ModelState.AddModelError("Erro", "Usuário não possui permissão para acessar o portal, " +
                "favor entre em contato com a equipe de TI.");
            }

            return View("Index", model);
        }

        [ValidateAntiForgeryToken]
        public virtual ActionResult Logoff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut("ActiveDirectoryAuthentication");
            return RedirectToAction("Index");
        }

    }
}