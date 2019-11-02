using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface IAcompanhamentoIntegracoesAppServices
    {
        IEnumerable<AcompanhamentoIntegracoesViewModel> ObterTodos();
        IEnumerable<AcompanhamentoIntegracoesViewModel> ObterPorData(DateTime dataLancamento);
        IEnumerable<AcompanhamentoIntegracoesViewModel> ObterPorDocumento(string documento);
        IEnumerable<AcompanhamentoIntegracoesViewModel> ObterPorLote(string lote);
    }
}
