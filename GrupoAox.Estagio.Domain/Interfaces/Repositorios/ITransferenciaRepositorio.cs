using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface ITransferenciaRepositorio : IRepositorio<Transferencia>
    {
        Transferencia Transferir(Transferencia transferencia);
        IEnumerable<Transferencia> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim);
        string ObterNumDocumento(Categoria categoria);
    }
}
