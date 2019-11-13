using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class LogTransferenciasController : Controller
    {
        private readonly ILogLotesAppServices _logLotesAppServices;

        public LogTransferenciasController(ILogLotesAppServices logLotesAppServices)
        {
            _logLotesAppServices = logLotesAppServices;
        }

        public ActionResult Index(string parametro = "", string busca = "", int pagina = 1, int tamanhoPagina = 50)
        {
            ViewBag.Busca = busca;
            ViewBag.Parametro = parametro;
            ViewBag.TamanhoPagina = tamanhoPagina;
            return View(SearchByParameter(parametro, busca).ToPagedList(pagina, tamanhoPagina));
        }

        private IEnumerable<LogLotesViewModel> SearchByParameter(string parametro = "", string busca = "")
        {
            //if (parametro == "periodo")
            //{
            //    var data = Convert.ToDateTime(busca);
            //    return _transferenciaAppServices.ObterPorData(data, "Romaneio");
            //}
            //else if (parametro == "numDocumento")

            if(parametro == "usuario")
            {
                return _logLotesAppServices.ObterPorUsuario(busca);
            }
            
            return _logLotesAppServices.ObterTodos();
        }


    }
}