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
        IEnumerable<TransferenciaViewModel> ObterTodos(string categoria);
        TransferenciaViewModel Transferir(TransferenciaViewModel transferencia);
        string ObterNumDocumento();
        IEnumerable<TransferenciaViewModel> ObterPorNumDocumento(string numDocumento, string categoria);
        IEnumerable<TransferenciaViewModel> ObterPorData(DateTime data, string categoria);
        IEnumerable<TransferenciaViewModel> ObterPorUsuario(string usuario, string categoria);
    }
}
