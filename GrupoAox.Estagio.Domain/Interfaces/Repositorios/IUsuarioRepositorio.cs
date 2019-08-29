using GrupoAox.Estagio.Domain.Entidades;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario ObterPorLogin(string login);
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> ObterPorNome(string nome);
        void SalvarImagem(int id, string caminhoImagem);
    }
}
