using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.MVC.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppServices _usuarioAppServices;
        private readonly IPermissaoAppServices _permissaoAppServices;
        public UsuarioController(IUsuarioAppServices usuarioAppServices, IPermissaoAppServices permissaoAppServices)
        {
            _usuarioAppServices = usuarioAppServices;
            _permissaoAppServices = permissaoAppServices;
        }

        public ActionResult Index(string parametro = "", string busca = "")
        {
            ViewBag.Parametro = parametro;
            ViewBag.Busca = busca;
            return View(PesquisarPorParametro(parametro, busca));
        }

        [HttpPost]
        public async Task<ActionResult> Novo(string usuario)
        {
            var retorno = await _usuarioAppServices.ImportarAD(usuario);
            Thread.Sleep(1000);
            TempData["UsuarioCadastrado"] = $"Usuário<strong> {retorno.Nome} <strong>importado com sucesso";
            return RedirectToAction("Index", "Usuarios");
        }

        public ActionResult ImportarAD(UsuarioViewModel usuario)
        {
            return View(usuario);
        }

        [HttpPost]
        public ActionResult PesquisarUsuarioAD(string parametro, string busca = null)
        {
            if (parametro == "login")
            {
                UsuarioViewModel usuarioViewModel = ActiveDirectorySearch.SearchUser(busca);
                return ImportarAD(usuarioViewModel);
            }
            else
            {
                return RedirectToAction("ImportarAD");
            }
        }

        public ActionResult Editar(int? id)
        {
            ViewBag.Permissoes = _permissaoAppServices.ObterTodos();
            return ObterViewPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(UsuarioViewModel usuario, string[] permissoes = null)
        {
            try
            {
                if (permissoes != null)
                {
                    foreach (var permissao in permissoes)
                    {
                        if (permissao != "false")
                        {
                            usuario.Permissoes.Add(_permissaoAppServices.ObterPorId(Convert.ToInt32(permissao)));
                        }
                    }
                }

                if (string.IsNullOrEmpty(usuario.Nome))
                {
                    ModelState.AddModelError("Nome", "O Nome é obrigatório");
                    ViewBag.Permissoes = _permissaoAppServices.ObterTodos();
                    return View(usuario);
                }

                if (string.IsNullOrEmpty(usuario.Email))
                {
                    ModelState.AddModelError("Email", "O Email é obrigatório");
                    ViewBag.Permissoes = _permissaoAppServices.ObterTodos();
                    return View(usuario);
                }

                if (string.IsNullOrEmpty(usuario.Login))
                {
                    ModelState.AddModelError("Login", "O Login é obrigatório");
                    ViewBag.Permissoes = _permissaoAppServices.ObterTodos();
                    return View(usuario);
                }

                //ClaimsExtensionMethod.AddUpdateClaim(User, model, _usuarioAppService);
                _usuarioAppServices.Alterar(usuario);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Permissoes = _permissaoAppServices.ObterTodos();
                return View(usuario);
            }
        }

        public ActionResult Remover(int? id)
        {
            ViewBag.Permissoes = _permissaoAppServices.ObterTodos();
            return ObterViewPorId(id);
        }

        [HttpPost]
        public ActionResult Remover(int id)
        {
            _usuarioAppServices.Remover(id);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int id)
        {
            ViewBag.Permissoes = _permissaoAppServices.ObterTodos();
            return View(_usuarioAppServices.ObterPorId(id));
        }

        private ActionResult ObterViewPorId(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel usuarioViewModel = _usuarioAppServices.ObterPorId((int)id);
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        public IEnumerable<UsuarioViewModel> PesquisarPorParametro(string parametro, string busca)
        {
            var retorno = new List<UsuarioViewModel>();
            if (parametro == "nome")
            {
                retorno = _usuarioAppServices.ObterPorNome(busca).ToList();
                return retorno;
            }
            else if (parametro == "login")
            {
                retorno.Add(_usuarioAppServices.ObterPorLogin(busca));
                return retorno;
            }
            else if (parametro == "email")
            {
                retorno.Add(_usuarioAppServices.ObterPorEmail(busca));
                return retorno;
            }
            retorno = _usuarioAppServices.ObterTodos().ToList();
            return retorno;
        }

        [HttpPost]
        public ActionResult SaveImage(HttpPostedFileBase postedImage)
        {
            //string fileExtension = postedImage.ContentType;
            //string login = User.Identity.GetUserLogin();
            //int id = User.Identity.GetUserId();

            //if (VerifyAllowExtensions(fileExtension))
            //{
            //    string path = "~/Images/ProfileImages/" +
            //        login + "." + fileExtension.Split('/')[1];

            //    DeleteExistingUserImage(login);

            //    postedImage.SaveAs(Server.MapPath(path));
            //    _usuarioAppServices.SaveImageUser(id, path);
            //    ClaimsExtensionMethod.UpdateImageClaim(User, id, _usuarioAppService);

            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    TempData["ExtensionError"] = "Selecione uma imagem em um formato válido(.jpg, .png, .gif)";
            //    return RedirectToAction("Index", "Home");
            //}
            throw new NotImplementedException();
        }

        private bool VerifyAllowExtensions(string fileExtension)
        {
            string[] allowExtensions = new string[] { "image/jpeg", "image/png", "image/gif" };

            if (allowExtensions.ToList().Contains(fileExtension))
            {
                return true;
            }

            return false;
        }

        private void DeleteExistingUserImage(string login)
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Images/ProfileImages/"));

            foreach (FileInfo f in di.GetFiles())
            {
                if (f.FullName.Contains(login))
                {
                    f.Delete();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _usuarioAppServices.Dispose();
                _permissaoAppServices.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}