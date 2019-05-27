using System.Threading.Tasks;

namespace GrupoAOX.Estagio.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
