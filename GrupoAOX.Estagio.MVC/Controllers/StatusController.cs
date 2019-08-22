using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusAppServices _statusAppServices;

        public StatusController(IStatusAppServices statusAppServices)
        {
            _statusAppServices = statusAppServices;
        }

        // GET: Status
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
        public ActionResult Novo(StatusViewModel statusViewModel)
        {
            if (ModelState.IsValid)
            {
                var statusRetorno = _statusAppServices.Adicionar(statusViewModel);
                if (!statusRetorno.ValidationResult.IsValid)
                {
                    foreach (var erro in statusRetorno.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(statusViewModel);
                }
                return RedirectToAction("Index");
            }
            return View(statusViewModel);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var status = _statusAppServices.ObterPorId((int)id);

            if (status == null)
            {
                return HttpNotFound();
            }

            return View(status);
        }

        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var status = _statusAppServices.ObterPorId((int)id);

            if (status == null)
            {
                return HttpNotFound();
            }

            return View(status);
        }

        [HttpPost]
        public ActionResult Editar(StatusViewModel statusViewModel)
        {
            if (ModelState.IsValid)
            {
                var statusRetorno = _statusAppServices.Atualizar(statusViewModel);
                return RedirectToAction("Index");
            }
            return View(statusViewModel);
        }

        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var status = _statusAppServices.ObterPorId((int)id);

            if (status == null)
            {
                return HttpNotFound();
            }

            return View(status);
        }

        [HttpPost]
        public ActionResult Remover(int id)
        {
            _statusAppServices.Remover(id);
            return RedirectToAction("Index");
        }

        private IEnumerable<StatusViewModel> PesquisarPorParametro(string parametro, string busca)
        {
            if (parametro == "descricao")
            {
                return _statusAppServices.ObterPorDescricao(busca);
            }
            return _statusAppServices.ObterTodos();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _statusAppServices.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}