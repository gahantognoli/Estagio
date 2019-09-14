using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface ILoteServices : IDisposable
    {
        IEnumerable<int_exp_Etiqueta_Producao> ObterTodos();
        int_exp_Etiqueta_Producao ObterPorId(int id);
        int_exp_Etiqueta_Producao ObterPorDocumento(string numDocumento);
        int_exp_Etiqueta_Producao ObterPorLote(string numLote);
        int_exp_Etiqueta_Producao AtualizarStatus(int id, int statusId);
        int_exp_Etiqueta_Producao Atualizar(int id, string armazem, int statusId, string romaneio, string tipoDocumento);

    }
}
