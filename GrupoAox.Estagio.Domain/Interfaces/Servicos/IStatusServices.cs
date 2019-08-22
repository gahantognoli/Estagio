using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface IStatusServices : IDisposable
    {
        Status Adicionar(Status status);
        Status Atualizar(Status status);
        void Remover(int id);
        Status ObterPorId(int id);
        IEnumerable<Status> ObterTodos();
        IEnumerable<Status> ObterPorDescricao(string descricao);
    }
}
