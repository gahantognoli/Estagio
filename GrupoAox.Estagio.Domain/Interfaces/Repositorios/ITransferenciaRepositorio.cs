using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface ITransferenciaRepositorio : IRepositorio<Transferencia>
    {
        int Transferir(Transferencia transferencia);
        IEnumerable<Transferencia> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}
