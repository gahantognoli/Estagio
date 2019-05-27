using GrupoAox.Estagio.Domain.Entidades;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario ObterPorLogin(string login);
        Usuario ObterPorEmail(string email);
        void SalvarImagem(int id, string caminhoImagem);
    }
}
