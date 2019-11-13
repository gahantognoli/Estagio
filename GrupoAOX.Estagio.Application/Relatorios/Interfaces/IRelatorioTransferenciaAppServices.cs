using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Relatorios.Interfaces
{
    public interface IRelatorioTransferenciaAppServices 
    {
        IEnumerable<Transferencia> ObterTransferencias(DateTime dataInicio, DateTime dataFim);
    }
}
