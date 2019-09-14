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
    public class LoteAppService : AppService, ILoteAppServices
    {
        private readonly ILoteServices _loteServices;

        public LoteAppService(ILoteServices loteServices, IUnitOfWork uow) : base(uow)
        {
            _loteServices = loteServices;
        }

        public int_exp_Etiqueta_ProducaoViewModel Atualizar(int id, string armazem, int statusId, string romaneio, string tipoDocumento)
        {
            var loteRetorno = _loteServices.Atualizar(id, armazem, statusId, romaneio, tipoDocumento);
            return Mapper.Map<int_exp_Etiqueta_ProducaoViewModel>(loteRetorno);
        }

        public int_exp_Etiqueta_ProducaoViewModel AtualizarStatus(int id, int statusId)
        {
            var loteRetorno = Mapper.Map<int_exp_Etiqueta_ProducaoViewModel>(_loteServices.AtualizarStatus(id, statusId));
            Commit();
            return loteRetorno;
        }

        public void Dispose()
        {
            _loteServices.Dispose();
            GC.SuppressFinalize(this);
        }

        public int_exp_Etiqueta_ProducaoViewModel ObterPorDocumento(string numDocumento)
        {
            return Mapper.Map<int_exp_Etiqueta_ProducaoViewModel>(_loteServices.ObterPorDocumento(numDocumento));
        }

        public int_exp_Etiqueta_ProducaoViewModel ObterPorId(int id)
        {
            return Mapper.Map<int_exp_Etiqueta_ProducaoViewModel>(_loteServices.ObterPorId(id));
        }

        public int_exp_Etiqueta_ProducaoViewModel ObterPorLote(string numLote)
        {
            return Mapper.Map<int_exp_Etiqueta_ProducaoViewModel>(_loteServices.ObterPorLote(numLote));
        }

        public IEnumerable<int_exp_Etiqueta_ProducaoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<int_exp_Etiqueta_ProducaoViewModel>>(_loteServices.ObterTodos());
        }


        
    }
}
