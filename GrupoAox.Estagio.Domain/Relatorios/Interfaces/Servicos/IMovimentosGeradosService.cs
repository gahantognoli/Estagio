using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos
{
    public interface IMovimentosGeradosService
    {
        IEnumerable<Movimento> ObterPorPeriodo(DateTime dataInicioMovimento, DateTime dataFimMovimento);
    }
}
