using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface ILogLotesAppServices
    {
        IEnumerable<LogLotesViewModel> ObterTodos();
        IEnumerable<LogLotesViewModel> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
        IEnumerable<LogLotesViewModel> ObterPorUsuario(string usuario);
    }
}
