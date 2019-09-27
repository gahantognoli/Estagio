using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios
{
    public interface IMovimentosGeradosRepositorio
    {
        IEnumerable<Movimento> ObterPorPeriodo(DateTime dataInicioMovimento, DateTime dataFimMovimento);
    }
}
