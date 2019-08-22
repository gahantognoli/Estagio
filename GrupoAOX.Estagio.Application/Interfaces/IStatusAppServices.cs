using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface IStatusAppServices : IDisposable
    {
        StatusViewModel Adicionar(StatusViewModel status);
        StatusViewModel Atualizar(StatusViewModel status);
        void Remover(int id);
        StatusViewModel ObterPorId(int id);
        IEnumerable<StatusViewModel> ObterTodos();
        IEnumerable<StatusViewModel> ObterPorDescricao(string descricao);
    }
}
