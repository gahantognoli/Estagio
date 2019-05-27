using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface IPermissaoServices : IDisposable
    {
        Permissao Adicionar(Permissao permissao);
        Permissao Atualizar(Permissao permissao);
        void Remover(int id);
        Permissao ObterPorId(int id);
        IEnumerable<Permissao> ObterTodos();
    }
}
