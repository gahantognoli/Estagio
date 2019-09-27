using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.Relatorios.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.MVC.Relatorios;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class OrdemExpedicaoController : Controller
    {
        private readonly ITransferenciaAppServices _transferenciaAppServices;
        private readonly IEntitySerializationServices<TransferenciaViewModel> _entitySerializationServices;
        private readonly ICategoriaAppServices _categoriaAppServices;
        private readonly IDocumentoTransferenciaAppService _documentoTransferenciaAppService;

        public OrdemExpedicaoController(ITransferenciaAppServices transferenciaAppServices,
            IEntitySerializationServices<TransferenciaViewModel> entitySerializationServices,
            ICategoriaAppServices categoriaAppServices, IDocumentoTransferenciaAppService documentoTransferenciaAppService)
        {
            _transferenciaAppServices = transferenciaAppServices;
            _entitySerializationServices = entitySerializationServices;
            _categoriaAppServices = categoriaAppServices;
            _documentoTransferenciaAppService = documentoTransferenciaAppService;

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
            return Json(new { retorno = new { ordemExpedicaoRetorno.ValidationResult, ordemExpedicaoRetorno.NumeroDocumento } }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Imprimir()
        {
            return View();
        }

        public ActionResult VisualizarPDF(string ordemExpedicao)
        {
            var dados = _documentoTransferenciaAppService.Visualizar(ordemExpedicao, "O");

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\RelatorioOrdemExpedicao.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Lotes);
            localReport.DataSources.Add(dataSource);

            var bytes = localReport.Render("PDF");

            return File(bytes, "application/pdf");
        }

        public ActionResult VisualizarExcel(string ordemExpedicao)
        {
            var dados = _documentoTransferenciaAppService.Visualizar(ordemExpedicao, "O");

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\RelatorioOrdemExpedicao.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Lotes);
            localReport.DataSources.Add(dataSource);

            localReport.DisplayName = "Ordem de Expedição - " + ordemExpedicao;
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