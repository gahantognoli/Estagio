using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaAppServices _categoriaAppServices;

        public CategoriaController(ICategoriaAppServices categoriaAppServices)
        {
            _categoriaAppServices = categoriaAppServices;
        }

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
        public ActionResult Novo(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoriaRetorno = _categoriaAppServices.Adicionar(categoriaViewModel);
                if (!categoriaRetorno.ValidationResult.IsValid)
                {
                    foreach (var erro in categoriaRetorno.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(categoriaViewModel);
                }
                return RedirectToAction("Index");
            }
            return View(categoriaViewModel);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = _categoriaAppServices.ObterPorId((int)id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaAppServices.Atualizar(categoriaViewModel);
                return RedirectToAction("Index");
            }
            return View(categoriaViewModel);
        }

        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = _categoriaAppServices.ObterPorId((int)id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var categoria = _categoriaAppServices.ObterPorId((int)id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(int id)
        {
            _categoriaAppServices.Remover(id);
            return RedirectToAction("Index");
        }

        private IEnumerable<CategoriaViewModel> PesquisarPorParametro(string parametro, string busca)
        {
            if (parametro == "descricao")
            {
                return _categoriaAppServices.ObterPorDescricao(busca);
            }
            return _categoriaAppServices.ObterTodos();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}