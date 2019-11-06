using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.MVC.Filters;
using GrupoAOX.Estagio.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    [Authorize]
    [ClaimsAutorize(ClaimType = ClaimTypes.Role, ClaimValue = "ADM,LEMBR")]
    public class LembreteController : Controller
    {
        private readonly ILembreteAppService _lembreteAppService;
        private readonly ITransferenciaAppServices _transferenciaAppServices;

        public LembreteController(ILembreteAppService lembreteAppService, ITransferenciaAppServices transferenciaAppServices)
        {
            _lembreteAppService = lembreteAppService;
            _transferenciaAppServices = transferenciaAppServices;
        }

        public ActionResult Index(string parametro = "", string busca = "")
        {
            var usuarioId = User.Identity.GetUserId();
            return View(PesquisarPorParametro(parametro, busca, usuarioId));
        }

        public ActionResult Adicionar(int transferenciaId)
        {
            ViewBag.TransferenciaId = transferenciaId;
            ViewBag.Lotes = _transferenciaAppServices.ObterPorId(transferenciaId);
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(LembreteViewModel lembrete)
        {
            if (!ModelState.IsValid)
                return View(lembrete);

            var usuarioId = User.Identity.GetUserId();

            lembrete.UsuarioId = usuarioId;
            var lembreteAdd = _lembreteAppService.Adicionar(lembrete);
            TempData["Sucesso"] = "Lembrete cadastrado com sucesso!";
            return RedirectToAction("Index", new { usuarioId = usuarioId });
        }

        public ActionResult Detalhes(int? id)
        {
            return ObterViewPorId(id);
        }

        public ActionResult Atualizar(int? id)
        {
            return ObterViewPorId(id);
        }

        [HttpPost]
        public ActionResult Atualizar(LembreteViewModel lembrete)
        {
            if (!ModelState.IsValid)
                return View(lembrete);

            var lembreteAt = _lembreteAppService.Atualizar(lembrete);
            TempData["Sucesso"] = "Lembrete atualizado com sucesso!";
            return RedirectToAction("Index");
        }

        public ActionResult Remover(int? id)
        {
            return ObterViewPorId(id);
        }

        [HttpPost]
        public ActionResult Remover(int id)
        {
            _lembreteAppService.Remover(id);
            TempData["Sucesso"] = "Lembrete removido com sucesso!";
            return RedirectToAction("Index");
        }

        public JsonResult MarcarConclusao(int id, bool concluido)
        {
            _lembreteAppService.MarcarConclusao(id, concluido);
            TempData["Sucesso"] = "Lembrete atualizado";
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        private ActionResult ObterViewPorId(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var lembrete = _lembreteAppService.ObterPorId((int)id);

            if (lembrete == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            return View(lembrete);
        }


        public IEnumerable<LembreteViewModel> PesquisarPorParametro(string parametro, string busca, int usuarioId)
        {
            if (parametro == "dataLancamento")
            {
                var dataLancamento = Convert.ToDateTime(busca);
                return _lembreteAppService.ObterPorDataLancamento(dataLancamento, usuarioId);
            }

            return _lembreteAppService.ObterTodos(usuarioId);
        }

    }
}