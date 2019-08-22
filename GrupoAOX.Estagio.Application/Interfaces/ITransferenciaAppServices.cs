using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface ITransferenciaAppServices : IDisposable
    {
        TransferenciaViewModel ObterPorId(int id);
        IEnumerable<TransferenciaViewModel> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
        IEnumerable<TransferenciaViewModel> ObterTodos();
        TransferenciaViewModel Transferir(TransferenciaViewModel transferencia);
    }
}
