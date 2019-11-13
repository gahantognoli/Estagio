using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAOX.Estagio.Application.Relatorios.Interfaces;
using GrupoAOX.Estagio.MVC.Filters;
using GrupoAOX.Estagio.MVC.Relatorios;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Web.Mvc;

namespace GrupoAOX.Estagio.MVC.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IEtiquetasGeradasAppService _etiquetasGeradasAppService;
        private readonly IMovimentosGeradosAppService _movimentosGeradosAppService;
        private readonly IRelatorioTransferenciaAppServices _relatorioTransferenciaAppServices;

        public RelatoriosController(IEtiquetasGeradasAppService etiquetasGeradasAppService,
            IMovimentosGeradosAppService movimentosGeradosAppService,
            IRelatorioTransferenciaAppServices relatorioTransferenciaAppServices)
        {
            _etiquetasGeradasAppService = etiquetasGeradasAppService;
            _movimentosGeradosAppService = movimentosGeradosAppService;
            _relatorioTransferenciaAppServices = relatorioTransferenciaAppServices;
        }

        // GET: Relatorios
        [ClaimsAutorize(ClaimType = ClaimTypes.Role, ClaimValue = "ADM,RELEG")]
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

        public ActionResult Transferencias()
        {
            return View();
        }

        public ActionResult TransferenciasExcel(string dataInicio, string dataFim)
        {
            var dataInicoConvertida = Convert.ToDateTime(dataInicio + " 00:00:00");
            var dataFimConvertida = Convert.ToDateTime(dataFim + " 23:59:59");

            var dados = _relatorioTransferenciaAppServices.ObterTransferencias(dataInicoConvertida, dataFimConvertida);

            var dataset = PopularDataset(dados);

            var localReport = new LocalReport();
            localReport.ReportPath = Request.MapPath(Request.ApplicationPath) + "bin\\Relatorios\\RelatorioTransferencias.rdlc";
            localReport.EnableExternalImages = true; //habilita imagens externas

            var dataSource = new ReportDataSource("DataSet1", (DataTable)dataset.Transferencias);
            localReport.DataSources.Add(dataSource);

            localReport.DisplayName = "Transferencias Geradas";
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

        [ClaimsAutorize(ClaimType = ClaimTypes.Role, ClaimValue = "ADM,MOVIG")]
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

        private DatasetTransferencias PopularDataset(IEnumerable<Transferencia> dados)
        {
            var dataset = new DatasetTransferencias();

            foreach (var item in dados)
            {
                var transferencia = dataset.Transferencias.NewTransferenciasRow();
                transferencia.TransferenciaId = item.TransferenciaId;
                transferencia.NumeroDocumento = item.NumeroDocumento;
                transferencia.DataMovimento = item.DataMovimento;
                transferencia.Etiqueta = item.Etiqueta;
                transferencia.DataLancamento = item.DataLancamento;
                transferencia.OrderProducao = item.OrderProducao;
                transferencia.ArmazemDestino = item.ArmazemDestino;
                transferencia.Produto = item.Produto;
                transferencia.QtdM2 = item.QtdM2;
                transferencia.QtdMetroLinear = item.QtdMetroLinear;
                transferencia.Categoria = item.Categoria;
                transferencia.NumDocumento = item.NumDocumento;
                transferencia.Status = item.Status;
                transferencia.Usuario = item.Usuario;
                dataset.Transferencias.AddTransferenciasRow(transferencia);
            }
            return dataset;
        }

    }
}