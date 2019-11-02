using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface IAcompanhamentoIntegracoesServices
    {
        IEnumerable<AcompanhamentoIntegracoes> ObterTodos();
        IEnumerable<AcompanhamentoIntegracoes> ObterPorData(DateTime dataLancamento);
        IEnumerable<AcompanhamentoIntegracoes> ObterPorDocumento(string documento);
        IEnumerable<AcompanhamentoIntegracoes> ObterPorLote(string lote);
    }
}
