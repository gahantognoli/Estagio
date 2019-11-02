using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface IAcompanhamentoIntegracoesRepositorio
    {
        IEnumerable<AcompanhamentoIntegracoes> ObterTodos();
        IEnumerable<AcompanhamentoIntegracoes> ObterPorData(DateTime dataLancamento);
        IEnumerable<AcompanhamentoIntegracoes> ObterPorDocumento(string documento);
        IEnumerable<AcompanhamentoIntegracoes> ObterPorLote(string lote);
    }
}
