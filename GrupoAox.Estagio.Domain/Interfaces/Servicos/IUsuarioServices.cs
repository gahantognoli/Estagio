using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface IUsuarioServices : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        void Remover(int id);
        Usuario ObterPorId(int id);
        IEnumerable<Usuario> ObterTodos();
        Usuario ObterPorLogin(string login);
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> ObterPorNome(string nome);
        void SalvarImagem(int id, string caminhoImagem);
    }
}
