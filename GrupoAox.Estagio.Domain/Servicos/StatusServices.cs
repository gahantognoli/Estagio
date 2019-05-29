using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Validations.Status;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class StatusServices : IStatusServices
    {
        private readonly IStatusRepositorio _statusRepositorio;

        public StatusServices(IStatusRepositorio statusRepositorio)
        {
            _statusRepositorio = statusRepositorio;
        }

        public Status Adicionar(Status status)
        {
            status.ValidationResult = new StatusAptoParaCadastroValidation(_statusRepositorio).Validate(status);
            return !status.ValidationResult.IsValid ? status : _statusRepositorio.Adicionar(status);
        }

        public Status Atualizar(Status status)
        {
            status.ValidationResult = new StatusAptoParaCadastroValidation(_statusRepositorio).Validate(status);
            return !status.ValidationResult.IsValid ? status : _statusRepositorio.Atualizar(status);
        }

        public void Dispose()
        {
            _statusRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Status ObterPorId(int id)
        {
            return _statusRepositorio.ObterPorId(id);
        }

        public IEnumerable<Status> ObterTodos()
        {
            return _statusRepositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _statusRepositorio.Remover(id);
        }
    }
}
