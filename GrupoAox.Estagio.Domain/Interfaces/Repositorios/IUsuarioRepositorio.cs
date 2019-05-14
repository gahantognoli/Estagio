using GrupoAox.Estagio.Domain.Entidades;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario ObterPorLogin(string login);
        void ImportarActiveDirectory(Usuario usuario);
    }
}
