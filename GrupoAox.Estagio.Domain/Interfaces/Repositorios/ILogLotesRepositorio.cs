using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface ILogLotesRepositorio
    {
        IEnumerable<LogLotes> ObterTodos();
        IEnumerable<LogLotes> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
        IEnumerable<LogLotes> ObterPorUsuario(string usuario);
    }
}
