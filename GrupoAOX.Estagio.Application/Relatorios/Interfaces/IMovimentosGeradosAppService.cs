using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Relatorios.Interfaces
{
    public interface IMovimentosGeradosAppService
    {
        IEnumerable<Movimento> ObterPorPeriodo(DateTime dataInicioMovimento, DateTime dataFimMovimento);
    }
}
