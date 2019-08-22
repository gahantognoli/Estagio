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
    public class StatusAppService : AppService, IStatusAppServices
    {
        private readonly IStatusServices _statusServices;

        public StatusAppService(IStatusServices statusServices, IUnitOfWork uow) : base(uow)
        {
            _statusServices = statusServices;
        }

        public StatusViewModel Adicionar(StatusViewModel status)
        {
            var retornoStatus = Mapper.Map<StatusViewModel>(_statusServices.Adicionar(Mapper.Map<Status>(status)));
            if (retornoStatus.ValidationResult.IsValid)
            {
                Commit();
            }
            return retornoStatus;
        }

        public StatusViewModel Atualizar(StatusViewModel status)
        {
            var retornoStatus = Mapper.Map<StatusViewModel>(_statusServices.Atualizar(Mapper.Map<Status>(status)));
            Commit();
            return retornoStatus;
        }

        public void Dispose()
        {
            _statusServices.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<StatusViewModel> ObterPorDescricao(string descricao)
        {
            return Mapper.Map<IEnumerable<StatusViewModel>>(_statusServices.ObterPorDescricao(descricao));
        }

        public StatusViewModel ObterPorId(int id)
        {
            return Mapper.Map<StatusViewModel>(_statusServices.ObterPorId(id));
        }

        public IEnumerable<StatusViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<StatusViewModel>>(_statusServices.ObterTodos());
        }

        public void Remover(int id)
        {
            _statusServices.Remover(id);
            Commit();
        }
    }
}
