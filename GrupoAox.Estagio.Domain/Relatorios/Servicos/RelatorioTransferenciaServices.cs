using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Relatorios.Servicos
{
    public class RelatorioTransferenciaServices : IRelatorioTransferenciaServices
    {
        private readonly IRelatorioTransferenciaRepositorio _transferenciaRepositorio;

        public RelatorioTransferenciaServices(IRelatorioTransferenciaRepositorio transferenciaRepositorio)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
        }

        public IEnumerable<Transferencia> ObterTransferencias(DateTime dataInicio, DateTime dataFim)
        {
            return _transferenciaRepositorio.ObterTransferencias(dataInicio, dataFim);
        }
    }
}
