using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface ILogLotesServices : IDisposable
    {
        IEnumerable<LogLotes> ObterTodos();
        IEnumerable<LogLotes> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
        IEnumerable<LogLotes> ObterPorUsuario(string usuario);
    }
}
