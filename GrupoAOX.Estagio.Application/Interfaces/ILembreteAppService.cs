using GrupoAOX.Estagio.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Interfaces
{
    public interface ILembreteAppService
    {
        LembreteViewModel Adicionar(LembreteViewModel lembrete);
        LembreteViewModel Atualizar(LembreteViewModel lembrete);
        void Remover(int id);
        LembreteViewModel ObterPorId(int id);
        IEnumerable<LembreteViewModel> ObterTodos(int usuarioId);
        IEnumerable<LembreteViewModel> ObterPorDataLancamento(DateTime dataLancamento, int usuarioId);
    }
}
