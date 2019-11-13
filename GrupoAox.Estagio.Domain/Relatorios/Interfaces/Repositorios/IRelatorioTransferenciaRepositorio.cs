using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios
{
    public interface IRelatorioTransferenciaRepositorio
    {
        IEnumerable<Transferencia> ObterTransferencias(DateTime dataInicio, DateTime dataFim);
    }
}
