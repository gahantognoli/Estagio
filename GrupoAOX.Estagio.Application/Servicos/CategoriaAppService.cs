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
    public class CategoriaAppService : AppService, ICategoriaAppServices
    {
        private readonly ICategoriaServices _categoriaServices;

        public CategoriaAppService(ICategoriaServices categoriaServices, IUnitOfWork uow) : base(uow)
        {
            _categoriaServices = categoriaServices;
        }

        public CategoriaViewModel Adicionar(CategoriaViewModel categoria)
        {
            var categoriaReturn = Mapper.Map<CategoriaViewModel>(_categoriaServices
                .Adicionar(Mapper.Map<Categoria>(categoria)));

            if (categoriaReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            return categoriaReturn;
        }

        public CategoriaViewModel Atualizar(CategoriaViewModel categoria)
        {
            var categoriaReturn = Mapper.Map<CategoriaViewModel>(_categoriaServices
                .Atualizar(Mapper.Map<Categoria>(categoria)));
            Commit();
            return categoriaReturn;
        }

        public void Dispose()
        {
            _categoriaServices.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CategoriaViewModel> ObterPorDescricao(string descricao)
        {
            return Mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaServices.ObterPorDescricao(descricao));
        }

        public CategoriaViewModel ObterPorId(int id)
        {
            return Mapper.Map<CategoriaViewModel>(_categoriaServices.ObterPorId(id));
        }

        public IEnumerable<CategoriaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CategoriaViewModel>>(_categoriaServices.ObterTodos());
        }

        public void Remover(int id)
        {
            _categoriaServices.Remover(id);
            Commit();
        }
    }
}
