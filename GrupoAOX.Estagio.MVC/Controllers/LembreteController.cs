using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class LembreteController : Controller
    {
        private readonly ILembreteAppService _lembreteAppService;
        private readonly ITransferenciaAppServices transferenciaAppServices;

        public LembreteController(ILembreteAppService lembreteAppService)
        {
            _lembreteAppService = lembreteAppService;
        }

        public ActionResult Index()
        {
            var usuarioId = User.Identity.GetUserId();
            return View(_lembreteAppService.ObterTodos(usuarioId));
        }

        public ActionResult Adicionar(int transferenciaId)
        {
            ViewBag.TransferenciaId = transferenciaId;
            ViewBag.Lotes = transferenciaAppServices.ObterPorId(transferenciaId);
            return View();
        }

    }
}