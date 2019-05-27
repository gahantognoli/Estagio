using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
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
            return _transferenciaRepositorio.Transferir(transferencia);
        }

        public void Dispose()
        {
            _transferenciaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
