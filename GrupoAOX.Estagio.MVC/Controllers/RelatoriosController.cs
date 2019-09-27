using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAOX.Estagio.Application.Relatorios.Interfaces;
using GrupoAOX.Estagio.MVC.Relatorios;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IEtiquetasGeradasAppService _etiquetasGeradasAppService;
        private readonly IMovimentosGeradosAppService _movimentosGeradosAppService;

        public RelatoriosController(IEtiquetasGeradasAppService etiquetasGeradasAppService,
            IMovimentosGeradosAppService movimentosGeradosAppService)
        {
            _etiquetasGeradasAppService = etiquetasGeradasAppService;
            _movimentosGeradosAppService = movimentosGeradosAppService;
        }

        // GET: Relatorios
        public ActionResult EtiquetasGeradas()
        {
            return View();
        }

        public ActionResult EtiquetasGeradasExcel(string dataInicio, string dataFim)
        {
            var dataInicoConvertida = Convert.ToDateTime(dataInicio + " 00:00:00");
            var dataFimConvertida = Convert.ToDateTime(dataFim + " 23:59:59");

            var dados = _etiquetasGeradasAppService.ObterEtiquetasGeradas(dataInicoConvertida, dataFimConvertida);

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\RelatorioEtiquetasGeradas.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Etiquetas);
            localReport.DataSources.Add(dataSource);

            localReport.DisplayName = "Etiquetas Geradas";
            var bytes = localReport.Render("EXCELOPENXML");

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        private DatasetRelatorioEtiquetasGeradas PopularDataset(IEnumerable<Etiqueta> dados)
        {
            var dataset = new DatasetRelatorioEtiquetasGeradas();

            foreach (var item in dados)
            {
                var etiqueta = dataset.Etiquetas.NewEtiquetasRow();
                etiqueta.OP = item.OP;
                etiqueta.NumEtiqueta = item.NumEtiqueta;
                etiqueta.Produto = item.Produto;
                etiqueta.PesoLiquido = item.PesoLiquido;
                etiqueta.PesoBruto = item.PesoBruto;
                etiqueta.QtdProducao = item.QtdProducao;
                etiqueta.QtdMetrosLineares = item.QtdMetrosLineares;
                etiqueta.DataLancamento = item.DataLancamento;
                etiqueta.Situacao = item.Situacao;
                etiqueta.Descartada = item.Descartada;
                etiqueta.IlhaImpressao = item.IlhaImpressao;
                etiqueta.LogIntegracao = item.LogIntegracao;
                dataset.Etiquetas.AddEtiquetasRow(etiqueta);
            }

            return dataset;
        }

        public ActionResult MovimentosGerados()
        {
            return View();
        }

        public ActionResult GerarRelatorioMovimentosGerados(string dataInicio, string dataFim, string exportarPara)
        {
            var dataInicoConvertida = Convert.ToDateTime(dataInicio + " 00:00:00");
            var dataFimConvertida = Convert.ToDateTime(dataFim + " 23:59:59");

            var dados = _movimentosGeradosAppService.ObterPorPeriodo(dataInicoConvertida, dataFimConvertida);

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\RelatorioMovimentosGerados.rdlc";
            localReport.EnableExternalImages = true; 

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Movimentos);
            localReport.DataSources.Add(dataSource);

            if (exportarPara == "excel")
            {
                localReport.DisplayName = "Movimentos Gerados";
                var bytes = localReport.Render("EXCELOPENXML");

                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
            else
            {
                var bytes = localReport.Render("PDF");
                return File(bytes, "application/pdf");
            }
        }

        private DatasetMovimentosGerados PopularDataset(IEnumerable<Movimento> dados)
        {
            var dataset = new DatasetMovimentosGerados();

            foreach (var item in dados)
            {
                var movimento = dataset.Movimentos.NewMovimentosRow();
                movimento.DataMovimento = item.DataMovimento;
                movimento.ArmazemDestino = item.ArmazemDestino;
                movimento.NumeroDocumento = item.NumeroDocumento;
                movimento.Usuario = item.Usuario;
                movimento.Lote = item.Lote;
                dataset.Movimentos.AddMovimentosRow(movimento);
            }

            return dataset;
        }

    }
}