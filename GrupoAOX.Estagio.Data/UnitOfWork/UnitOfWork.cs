using System.Threading.Tasks;
using GrupoAOX.Estagio.Data.Contexto;

namespace GrupoAOX.Estagio.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextoEstagio _contexto;
        private bool _disposed;

        public UnitOfWork(ContextoEstagio contexto)
        {
            _contexto = contexto;
            _disposed = false;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _contexto.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
