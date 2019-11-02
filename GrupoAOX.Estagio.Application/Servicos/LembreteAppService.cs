using AutoMapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Servicos
{
    public class LembreteAppService : AppService, ILembreteAppService
    {
        private readonly ILembreteService _lembreteService;

        public LembreteAppService(ILembreteService lembreteService, IUnitOfWork uow) : base(uow)
        {
            _lembreteService = lembreteService;
        }

        public LembreteViewModel Adicionar(LembreteViewModel lembrete)
        {
            var lembreteAdd = Mapper.Map<LembreteViewModel>(_lembreteService.Adicionar(Mapper.Map<Lembrete>(lembrete)));
            Commit();
            return lembreteAdd;
        }

        public LembreteViewModel Atualizar(LembreteViewModel lembrete)
        {
            var lembreteAt = Mapper.Map<LembreteViewModel>(_lembreteService.Atualizar(Mapper.Map<Lembrete>(lembrete)));
            Commit();
            return lembreteAt;
        }

        public IEnumerable<LembreteViewModel> ObterPorDataLancamento(DateTime dataLancamento, int usuarioId)
        {
            return Mapper.Map<IEnumerable<LembreteViewModel>>(_lembreteService.ObterPorDataLancamento(dataLancamento, usuarioId));
        }

        public LembreteViewModel ObterPorId(int id)
        {
            return Mapper.Map<LembreteViewModel>(_lembreteService.ObterPorId(id));
        }

        public IEnumerable<LembreteViewModel> ObterTodos(int usuarioId)
        {
            return Mapper.Map<IEnumerable<LembreteViewModel>>(_lembreteService.ObterTodos(usuarioId));
        }

        public void Remover(int id)
        {
            _lembreteService.Remover(id);
            Commit();
        }
    }
}
