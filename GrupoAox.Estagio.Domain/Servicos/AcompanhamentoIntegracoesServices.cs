using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class AcompanhamentoIntegracoesServices : IAcompanhamentoIntegracoesServices
    {
        private readonly IAcompanhamentoIntegracoesRepositorio _acompanhamentoIntegracoesRepositorio;

        public AcompanhamentoIntegracoesServices(IAcompanhamentoIntegracoesRepositorio acompanhamentoIntegracoesRepositorio)
        {
            _acompanhamentoIntegracoesRepositorio = acompanhamentoIntegracoesRepositorio;
        }

        public IEnumerable<AcompanhamentoIntegracoes> ObterPorData(DateTime dataLancamento)
        {
            return _acompanhamentoIntegracoesRepositorio.ObterPorData(dataLancamento);
        }

        public IEnumerable<AcompanhamentoIntegracoes> ObterPorDocumento(string documento)
        {
            return _acompanhamentoIntegracoesRepositorio.ObterPorDocumento(documento);
        }

        public IEnumerable<AcompanhamentoIntegracoes> ObterPorLote(string lote)
        {
            return _acompanhamentoIntegracoesRepositorio.ObterPorLote(lote);
        }

        public IEnumerable<AcompanhamentoIntegracoes> ObterTodos()
        {
            return _acompanhamentoIntegracoesRepositorio.ObterTodos();
        }
    }
}
