using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface ILembreteRepositorio : IRepositorio<Lembrete>
    {
        IEnumerable<Lembrete> ObterTodos(int usuarioId);
        IEnumerable<Lembrete> ObterPorDataLancamento(DateTime dataLancamento, int usuarioId);
        void MarcarConclusao(int lembreteId, bool concluido);
    }
}
