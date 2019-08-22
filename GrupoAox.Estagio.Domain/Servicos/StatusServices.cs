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
            if (status.ValidationResult.IsValid)
            {
                var statusRetorno = _statusRepositorio.Adicionar(status);
                statusRetorno.ValidationResult = status.ValidationResult;
                return statusRetorno;
            }
            else
            {
                return status;
            }
        }

        public Status Atualizar(Status status)
        {
            return _statusRepositorio.Atualizar(status);
        }

        public void Dispose()
        {
            _statusRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Status> ObterPorDescricao(string descricao)
        {
            return _statusRepositorio.ObterPorDescricao(descricao);
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
