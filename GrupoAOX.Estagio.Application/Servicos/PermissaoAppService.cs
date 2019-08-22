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
    public class PermissaoAppService : AppService, IPermissaoAppServices
    {
        private readonly IPermissaoServices _permissaoServices;

        public PermissaoAppService(IPermissaoServices permissaoServices, IUnitOfWork uow) : base(uow)
        {
            _permissaoServices = permissaoServices;
        }

        public PermissaoViewModel Adicionar(PermissaoViewModel permissao)
        {
            var permissaoReturn = Mapper.Map<PermissaoViewModel>(_permissaoServices
                .Adicionar(Mapper.Map<Permissao>(permissao)));

            if (permissaoReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            return permissaoReturn;
        }

        public PermissaoViewModel Atualizar(PermissaoViewModel permissao)
        {
            var permissaoReturn = Mapper.Map<PermissaoViewModel>(_permissaoServices
                .Atualizar(Mapper.Map<Permissao>(permissao)));

            if (permissaoReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            return permissaoReturn;
        }

        public void Dispose()
        {
            _permissaoServices.Dispose();
            GC.SuppressFinalize(this);
        }

        public PermissaoViewModel ObterPorId(int id)
        {
            return Mapper.Map<PermissaoViewModel>(_permissaoServices.ObterPorId(id));
        }

        public IEnumerable<PermissaoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PermissaoViewModel>>(_permissaoServices.ObterTodos());
        }

        public void Remover(int id)
        {
            _permissaoServices.Remover(id);
            Commit();
        }
    }
}
