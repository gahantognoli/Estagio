using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using System.Net;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class PermissaoController : Controller
    {
        private readonly IPermissaoAppServices _permissaoAppServices;

        public PermissaoController(IPermissaoAppServices permissaoAppServices)
        {
            _permissaoAppServices = permissaoAppServices;
        }

        // GET: Permissao
        public ActionResult Index()
        {
            return View(_permissaoAppServices.ObterTodos());
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(PermissaoViewModel permissaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var permissaoRetorno = _permissaoAppServices.Adicionar(permissaoViewModel);
                if (!permissaoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in permissaoRetorno.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(permissaoViewModel);
                }
                return RedirectToAction("Index");
            }
            return View(permissaoViewModel);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var permissao = _permissaoAppServices.ObterPorId((int)id);

            if (permissao == null)
            {
                return HttpNotFound();
            }

            return View(permissao);
        }

        [HttpPost]
        public ActionResult Editar(PermissaoViewModel permissaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var permissaoRetorno = _permissaoAppServices.Atualizar(permissaoViewModel);
                if (!permissaoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in permissaoRetorno.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(permissaoViewModel);
                }
                return RedirectToAction("Index");
            }
            return View(permissaoViewModel);
        }

        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var permissao = _permissaoAppServices.ObterPorId((int)id);

            if (permissao == null)
            {
                return HttpNotFound();
            }

            return View(permissao);
        }

        [HttpPost]
        public ActionResult Remover(int id)
        {
            _permissaoAppServices.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}