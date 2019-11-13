using GrupoAOX.Estagio.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class DashboardIntegracaoController : Controller
    {
        private readonly IDashboardAppServices _dashboardAppServices;

        public DashboardIntegracaoController(IDashboardAppServices dashboardAppServices)
        {
            _dashboardAppServices = dashboardAppServices;
        }

        public ActionResult Index()
        {
            ViewBag.LotesIntegrados = _dashboardAppServices.ObterLotesIntegrados();
            ViewBag.LotesAguardandoIntegracao = _dashboardAppServices.ObterLotesAguardandoIntegracao();
            ViewBag.LotesFalhaIntegracao = _dashboardAppServices.ObterLotesFalhaIntegracao();
            return View();
        }
    }
}