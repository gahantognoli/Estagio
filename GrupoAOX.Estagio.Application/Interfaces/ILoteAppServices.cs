using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface ILoteAppServices : IDisposable
    {
        IEnumerable<int_exp_Etiqueta_ProducaoViewModel> ObterTodos();
        int_exp_Etiqueta_ProducaoViewModel ObterPorId(int id);
        int_exp_Etiqueta_ProducaoViewModel ObterPorDocumento(string numDocumento);
        int_exp_Etiqueta_ProducaoViewModel ObterPorLote(string numLote);
        int_exp_Etiqueta_ProducaoViewModel AtualizarStatus(int id, int statusId);
        int_exp_Etiqueta_ProducaoViewModel Atualizar(int id, string armazem, int statusId, string romaneio, string tipoDocumento);
    }
}
