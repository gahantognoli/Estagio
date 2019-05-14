using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        protected ContextoEstagio Db;
        protected DbSet<TEntity> DbSet;

        public Repositorio(ContextoEstagio contextoEstagio)
        {
            Db = contextoEstagio;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Adicionar(TEntity obj)
        {
            return DbSet.Add(obj);
        }

        public TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            return obj;
        }

        public TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return DbSet.Where(predicado);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
