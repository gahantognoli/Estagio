using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity Atualizar(TEntity obj);
        void Remover(int id);
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado);
        int SaveChanges();
    }
}
