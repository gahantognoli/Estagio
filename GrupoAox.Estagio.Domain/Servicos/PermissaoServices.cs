using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class PermissaoServices : IPermissaoServices
    {
        private readonly IPermissaoRepositorio _permissaoRepositorio;

        public PermissaoServices(IPermissaoRepositorio permissaoRepositorio)
        {
            _permissaoRepositorio = permissaoRepositorio;
        }

        public Permissao Adicionar(Permissao permissao)
        {
            //permissao.ValidationResult = new PermissaoEstaAptoParaCadastro(_permissaoRepositorio).Validate(permissao);

            //return !permissao.ValidationResult.IsValid ? permissao : _permissaoRepositorio.Adicionar(permissao);

            return _permissaoRepositorio.Adicionar(permissao);
        }

        public Permissao Atualizar(Permissao permissao)
        {
            //permissao.ValidationResult = new PermissaoEstaAptoParaCadastro(_permissaoRepositorio).Validate(permissao);

            //return !permissao.ValidationResult.IsValid ? permissao : _permissaoRepositorio.Adicionar(permissao);

            return _permissaoRepositorio.Atualizar(permissao);
        }

        public void Dispose()
        {
            _permissaoRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Permissao ObterPorId(int id)
        {
            return _permissaoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Permissao> ObterTodos()
        {
            return _permissaoRepositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _permissaoRepositorio.Remover(id);
        }
    }
}
