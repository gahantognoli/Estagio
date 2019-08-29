using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Validations.Usuarios;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServices(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuario.ValidationResult = new UsuarioAptoParaCadastroValidation(_usuarioRepositorio).Validate(usuario);
            return !usuario.ValidationResult.IsValid ? usuario : _usuarioRepositorio.Adicionar(usuario);
        }

        public Usuario Alterar(Usuario usuario)
        {
            usuario.ValidationResult = new UsuarioAptoParaCadastroValidation(_usuarioRepositorio).Validate(usuario);
            return !usuario.ValidationResult.IsValid ? usuario : _usuarioRepositorio.Adicionar(usuario);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepositorio.ObterTodos();
        }

        public Usuario ObterPorId(int id)
        {
            return _usuarioRepositorio.ObterPorId(id);
        }

        public Usuario ObterPorEmail(string email)
        {
            return _usuarioRepositorio.ObterPorEmail(email);
        }

        public Usuario ObterPorLogin(string login)
        {
            return _usuarioRepositorio.ObterPorLogin(login);
        }

        public void Remover(int id)
        {
            _usuarioRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Usuario> ObterPorNome(string nome)
        {
            return _usuarioRepositorio.ObterPorNome(nome);
        }
    }
}
