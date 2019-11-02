using GrupoAox.Estagio.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface ILembreteService : IDisposable
    {
        Lembrete Adicionar(Lembrete lembrete);
        Lembrete Atualizar(Lembrete lembrete);
        void Remover(int id);
        Lembrete ObterPorId(int id);
        IEnumerable<Lembrete> ObterTodos(int usuarioId);
        IEnumerable<Lembrete> ObterPorDataLancamento(DateTime dataLancamento, int usuarioId);
    }
}
