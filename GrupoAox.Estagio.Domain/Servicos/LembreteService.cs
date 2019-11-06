using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class LembreteService : ILembreteService
    {
        private readonly ILembreteRepositorio _lembreteRepositorio;

        public LembreteService(ILembreteRepositorio lembreteRepositorio)
        {
            _lembreteRepositorio = lembreteRepositorio;
        }

        public Lembrete Adicionar(Lembrete lembrete)
        {
            return _lembreteRepositorio.Adicionar(lembrete);
        }

        public Lembrete Atualizar(Lembrete lembrete)
        {
            return _lembreteRepositorio.Atualizar(lembrete);
        }

        public void Dispose()
        {
            _lembreteRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public void MarcarConclusao(int lembreteId, bool concluido)
        {
            _lembreteRepositorio.MarcarConclusao(lembreteId, concluido);
        }

        public IEnumerable<Lembrete> ObterPorDataLancamento(DateTime dataLancamento, int usuarioId)
        {
            return _lembreteRepositorio.ObterPorDataLancamento(dataLancamento, usuarioId);
        }

        public Lembrete ObterPorId(int id)
        {
            return _lembreteRepositorio.ObterPorId(id);
        }

        public IEnumerable<Lembrete> ObterTodos(int usuarioId)
        {
            return _lembreteRepositorio.ObterTodos(usuarioId);
        }

        public void Remover(int id)
        {
            _lembreteRepositorio.Remover(id);
        }
    }
}
