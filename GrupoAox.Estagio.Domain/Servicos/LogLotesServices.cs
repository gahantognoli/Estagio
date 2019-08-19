using System;
using System.Collections.Generic;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class LogLotesServices : ILogLotesServices
    {
        private readonly ILogLotesRepositorio _logLotesRepositorio;

        public LogLotesServices(ILogLotesRepositorio logLotesRepositorio)
        {
            _logLotesRepositorio = logLotesRepositorio;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<LogLotes> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _logLotesRepositorio.ObterPorPeriodo(dataInicio, dataFim);
        }

        public IEnumerable<LogLotes> ObterPorUsuario(string usuario)
        {
            return _logLotesRepositorio.ObterPorUsuario(usuario);
        }

        public IEnumerable<LogLotes> ObterTodos()
        {
            return _logLotesRepositorio.ObterTodos();
        }
    }
}
