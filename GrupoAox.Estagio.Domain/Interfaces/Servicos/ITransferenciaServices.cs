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
        Transferencia Transferir(Transferencia transferencia);
    }
}
