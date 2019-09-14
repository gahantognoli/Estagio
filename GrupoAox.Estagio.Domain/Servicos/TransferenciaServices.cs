using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Validations.Transferencias;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class TransferenciaServices : ITransferenciaServices
    {
        private readonly ITransferenciaRepositorio _transferenciaRepositorio;

        public TransferenciaServices(ITransferenciaRepositorio transferenciaRepositorio)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
        }

        public Transferencia ObterPorId(int id)
        {
            return _transferenciaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Transferencia> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _transferenciaRepositorio.ObterPorPeriodo(dataInicio, dataFim);
        }

        public IEnumerable<Transferencia> ObterTodos()
        {
            return _transferenciaRepositorio.ObterTodos();
        }

        public Transferencia Transferir(Transferencia transferencia)
        {
            transferencia.ValidationResult = new TransferenciaAptaParaCadastro().Validate(transferencia);
            return !transferencia.ValidationResult.IsValid ? transferencia :
                _transferenciaRepositorio.Transferir(transferencia);
        }

        public void Dispose()
        {
            _transferenciaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public string ObterNumDocumento()
        {
            return _transferenciaRepositorio.ObterNumDocumento();
        }
    }
}
