using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface ICategoriaAppServices : IDisposable
    {
        CategoriaViewModel Adicionar(CategoriaViewModel categoria);
        CategoriaViewModel Atualizar(CategoriaViewModel categoria);
        void Remover(int id);
        CategoriaViewModel ObterPorId(int id);
        IEnumerable<CategoriaViewModel> ObterTodos();
        IEnumerable<CategoriaViewModel> ObterPorDescricao(string descricao);
    }
}
