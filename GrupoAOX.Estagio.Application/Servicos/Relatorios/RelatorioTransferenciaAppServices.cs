using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Relatorios.Interfaces;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Servicos.Relatorios
{
    public class RelatorioTransferenciaAppServices : IRelatorioTransferenciaAppServices
    {
        private readonly IRelatorioTransferenciaServices _transferenciaServices;

        public RelatorioTransferenciaAppServices(IRelatorioTransferenciaServices transferenciaServices)
        {
            _transferenciaServices = transferenciaServices;
        }

        public IEnumerable<Transferencia> ObterTransferencias(DateTime dataInicio, DateTime dataFim)
        {
            return _transferenciaServices.ObterTransferencias(dataInicio, dataFim);
        }
    }
}
