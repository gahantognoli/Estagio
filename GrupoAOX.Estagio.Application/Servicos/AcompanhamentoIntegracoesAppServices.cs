using AutoMapper;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Servicos
{
    public class AcompanhamentoIntegracoesAppServices : IAcompanhamentoIntegracoesAppServices
    {
        private readonly IAcompanhamentoIntegracoesServices _acompanhamentoIntegracoesServices;

        public AcompanhamentoIntegracoesAppServices(IAcompanhamentoIntegracoesServices acompanhamentoIntegracoesServices)
        {
            _acompanhamentoIntegracoesServices = acompanhamentoIntegracoesServices;
        }

        public IEnumerable<AcompanhamentoIntegracoesViewModel> ObterPorData(DateTime dataLancamento)
        {
            return Mapper.Map<IEnumerable<AcompanhamentoIntegracoesViewModel>>(_acompanhamentoIntegracoesServices.ObterPorData(dataLancamento));
        }

        public IEnumerable<AcompanhamentoIntegracoesViewModel> ObterPorDocumento(string documento)
        {
            return Mapper.Map<IEnumerable<AcompanhamentoIntegracoesViewModel>>(_acompanhamentoIntegracoesServices.ObterPorDocumento(documento));
        }

        public IEnumerable<AcompanhamentoIntegracoesViewModel> ObterPorLote(string lote)
        {
            return Mapper.Map<IEnumerable<AcompanhamentoIntegracoesViewModel>>(_acompanhamentoIntegracoesServices.ObterPorLote(lote));
        }

        public IEnumerable<AcompanhamentoIntegracoesViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AcompanhamentoIntegracoesViewModel>>(_acompanhamentoIntegracoesServices.ObterTodos());
        }
    }
}
