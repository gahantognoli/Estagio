using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class OrdemExpedicaoController : Controller
    {
        private readonly ITransferenciaAppServices _transferenciaAppServices;
        private readonly IEntitySerializationServices<TransferenciaViewModel> _entitySerializationServices;
        private readonly ICategoriaAppServices _categoriaAppServices;

        public OrdemExpedicaoController(ITransferenciaAppServices transferenciaAppServices,
            IEntitySerializationServices<TransferenciaViewModel> entitySerializationServices,
            ICategoriaAppServices categoriaAppServices)
        {
            _transferenciaAppServices = transferenciaAppServices;
            _entitySerializationServices = entitySerializationServices;
            _categoriaAppServices = categoriaAppServices;

        }

        public ActionResult Novo()
        {
            ViewBag.CategoriaId = _categoriaAppServices.ObterPorDescricao("Ordem de Expedição")
                .FirstOrDefault().CategoriaId;
            ViewBag.NumDocumento = _transferenciaAppServices.ObterNumDocumento();
            return View();
        }

        [HttpPost]
        public JsonResult Novo(string requisicao)
        {
            var ordemExpedicao = _entitySerializationServices.Deserialize(requisicao);
            var ordemExpedicaoRetorno = _transferenciaAppServices.Transferir(ordemExpedicao);
            return Json(new { retorno = ordemExpedicaoRetorno }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ObterArmazens(string filial)
        {
            var url = "http://portal.grupoaox.com.br:8090/api/Armazem?filial=" + filial;
            var http = WebRequest.CreateHttp(url);
            http.Method = "GET";
            var armazens = "";
            using (var resposta = http.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader stream = new StreamReader(streamDados);
                armazens = stream.ReadToEnd();
            }
            return Json(armazens, JsonRequestBehavior.AllowGet);
        }
    }
}