using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface ICategoriaServices : IDisposable
    {
        Categoria Adicionar(Categoria categoria);
        Categoria Atualizar(Categoria categoria);
        void Remover(int id);
        Categoria ObterPorId(int id);
        IEnumerable<Categoria> ObterTodos();
    }
}
