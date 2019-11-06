using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.Relatorios.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.MVC.Filters;
using GrupoAOX.Estagio.MVC.Helpers;
using GrupoAOX.Estagio.MVC.Relatorios;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Mvc;
using X.PagedList;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    [Authorize]
    [ClaimsAutorize(ClaimType = ClaimTypes.Role, ClaimValue = "ADM,ROM")]
    public class RomaneioController : Controller
    {
        private readonly ITransferenciaAppServices _transferenciaAppServices;
        private readonly IEntitySerializationServices<TransferenciaViewModel> _entitySerializationServices;
        private readonly ICategoriaAppServices _categoriaAppServices;
        private readonly IDocumentoTransferenciaAppService _documentoTransferenciaAppService;

        public RomaneioController(ITransferenciaAppServices transferenciaAppServices,
            IEntitySerializationServices<TransferenciaViewModel> entitySerializationServices,
            ICategoriaAppServices categoriaAppServices, IDocumentoTransferenciaAppService documentoTransferenciaAppService)
        {
            _transferenciaAppServices = transferenciaAppServices;
            _entitySerializationServices = entitySerializationServices;
            _categoriaAppServices = categoriaAppServices;
            _documentoTransferenciaAppService = documentoTransferenciaAppService;
        }

        public ActionResult Index(string parametro = "", string busca = "", int pagina = 1, int tamanhoPagina = 50)
        {
            ViewBag.Busca = busca;
            ViewBag.Parametro = parametro;
            ViewBag.TamanhoPagina = tamanhoPagina;
            return View(SearchByParameter(parametro, busca).ToPagedList(pagina, tamanhoPagina));
        }

        private IEnumerable<TransferenciaViewModel> SearchByParameter(string parametro = "", string busca = "")
        {
            if (parametro == "data")
            {
                var data = Convert.ToDateTime(busca);
                return _transferenciaAppServices.ObterPorData(data, "Romaneio");
            }
            else if (parametro == "numDocumento")
            {
                return _transferenciaAppServices.ObterPorNumDocumento(busca, "Romaneio");
            }
            else if (parametro == "usuario")
            {
                return _transferenciaAppServices.ObterPorUsuario(busca, "Romaneio");
            }
            return _transferenciaAppServices.ObterTodos("Romaneio");
        }

        public ActionResult Novo()
        {
            ViewBag.CategoriaId = _categoriaAppServices.ObterPorDescricao("Romaneio")
                .FirstOrDefault().CategoriaId;
            ViewBag.NumDocumento = _transferenciaAppServices.ObterNumDocumento();
            return View();
        }

        [HttpPost]
        public JsonResult Novo(string requisicao)
        {
            var romaneio = _entitySerializationServices.Deserialize(requisicao);
            romaneio.UsuarioId = User.Identity.GetUserId();
            var romaneioRetorno = _transferenciaAppServices.Transferir(romaneio);
            return Json(new { retorno = new { romaneioRetorno.ValidationResult, romaneio.NumeroDocumento } }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Imprimir(string numDocumento = null)
        {
            ViewBag.NumDocumento = numDocumento;
            return View();
        }

        public ActionResult VisualizarPDF(string numRomaneio)
        {
            var dados = _documentoTransferenciaAppService.Visualizar(numRomaneio, "R");

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\RelatorioRomaneioTransferencia.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Lotes);
            localReport.DataSources.Add(dataSource);

            var bytes = localReport.Render("PDF");

            return File(bytes, "application/pdf");
        }

        public ActionResult VisualizarExcel(string numRomaneio)
        {
            var dados = _documentoTransferenciaAppService.Visualizar(numRomaneio, "R");

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\RelatorioRomaneioTransferencia.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Lotes);
            localReport.DataSources.Add(dataSource);

            localReport.DisplayName = "Romaneio - " + numRomaneio;
            var bytes = localReport.Render("EXCELOPENXML");

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        private DatasetRelatorioDocumentoTransferencia PopularDataset(IEnumerable<DocumentoTransferencia> dados)
        {
            var dataset = new DatasetRelatorioDocumentoTransferencia();

            foreach (var item in dados)
            {
                var lote = dataset.Lotes.NewLotesRow();
                lote.Palete = item.Palete;
                lote.OP = item.OP;
                lote.Produto = item.Produto;
                lote.PesoLiquido = item.PesoLiquido;
                lote.PesoBruto = item.PesoBruto;
                lote.QuantidadeM2 = item.QuantidadeM2;
                lote.QuantidadeMT = item.QuantidadeMT;
                lote.Local = item.Local;
                lote.Observacao = item.Observacao;
                lote.Armazem = item.Armazem;
                lote.NumDocumento = item.NumDocumento;
                dataset.Lotes.AddLotesRow(lote);
            }

            return dataset;
        }

        public JsonResult ObterArmazens(string filial, string parametro, string pesquisa)
        {
            var url = "http://portal.grupoaox.com.br:8090/api/Armazem?filial=" + filial 
                + "&parametro=" + parametro + "&pesquisa=" + pesquisa;
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