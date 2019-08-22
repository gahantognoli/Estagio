using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface IPermissaoAppServices : IDisposable
    {
        PermissaoViewModel Adicionar(PermissaoViewModel permissao);
        PermissaoViewModel Atualizar(PermissaoViewModel permissao);
        void Remover(int id);
        PermissaoViewModel ObterPorId(int id);
        IEnumerable<PermissaoViewModel> ObterTodos();
    }
}
