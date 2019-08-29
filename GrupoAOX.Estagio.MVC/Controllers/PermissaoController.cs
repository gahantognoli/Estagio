using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index(string parametro = "", string busca = "")
        {
            ViewBag.Parametro = parametro;
            ViewBag.Busca = busca;
            return View(PesquisarPorParametro(parametro, busca));
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(PermissaoViewModel permissaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var permissaoRetorno = _permissaoAppServices.Adicionar(permissaoViewModel);
                if (!permissaoRetorno.ValidationResult.IsValid)
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

        public ActionResult Detalhes(int? id)
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
        [ValidateAntiForgeryToken]
        public ActionResult Editar(PermissaoViewModel permissaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var permissaoRetorno = _permissaoAppServices.Atualizar(permissaoViewModel);
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
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id)
        {
            _permissaoAppServices.Remover(id);
            return RedirectToAction("Index");
        }

        private IEnumerable<PermissaoViewModel> PesquisarPorParametro(string parametro, string busca)
        {
            List<PermissaoViewModel> retorno = new List<PermissaoViewModel>();
            if (parametro == "descricao")
            {
                retorno = _permissaoAppServices.ObterPorDescricao(busca).ToList();
                return retorno;
            }
            else if (parametro == "sigla")
            {
                retorno.Add(_permissaoAppServices.ObterPorSigla(busca));
                return retorno;
            }
            return _permissaoAppServices.ObterTodos();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}