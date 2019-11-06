using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Mvc;
using X.PagedList;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    [Authorize]
    [ClaimsAutorize(ClaimType = ClaimTypes.Role, ClaimValue = "ADM,ACINT")]
    public class AcompanhamentoIntegracoesController : Controller
    {
        private readonly IAcompanhamentoIntegracoesAppServices _acompanhamentoIntegracoesAppServices;

        public AcompanhamentoIntegracoesController(IAcompanhamentoIntegracoesAppServices acompanhamentoIntegracoesAppServices)
        {
            _acompanhamentoIntegracoesAppServices = acompanhamentoIntegracoesAppServices;
        }


        public ActionResult Index(string parametro = "", string busca = "", int pagina = 1, int tamanhoPagina = 50)
        {
            ViewBag.Busca = busca;
            ViewBag.Parametro = parametro;
            ViewBag.TamanhoPagina = tamanhoPagina;
            return View(SearchByParameter(parametro, busca).ToPagedList(pagina, tamanhoPagina));
        }

        private IEnumerable<AcompanhamentoIntegracoesViewModel> SearchByParameter(string parametro = "", string busca = "")
        {
            if (parametro == "data")
            {
                var data = Convert.ToDateTime(busca);
                return _acompanhamentoIntegracoesAppServices.ObterPorData(data);
            }
            else if (parametro == "lote")
            {
                return _acompanhamentoIntegracoesAppServices.ObterPorLote(busca.Trim());
            }
            else if (parametro == "documento")
            {
                return _acompanhamentoIntegracoesAppServices.ObterPorDocumento(busca.Trim());
            }

            return _acompanhamentoIntegracoesAppServices.ObterTodos();
        }
    }
}