using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface ITransferenciaServices : IDisposable
    {
        Transferencia ObterPorId(int id);
        IEnumerable<Transferencia> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
        IEnumerable<Transferencia> ObterTodos();
        IEnumerable<Transferencia> ObterTodos(string categoria);
        Transferencia Transferir(Transferencia transferencia);
        string ObterNumDocumento();
        IEnumerable<Transferencia> ObterPorNumDocumento(string numDocumento, string categoria);
        IEnumerable<Transferencia> ObterPorData(DateTime data, string categoria);
        IEnumerable<Transferencia> ObterPorUsuario(string usuario, string categoria);
    }
}
