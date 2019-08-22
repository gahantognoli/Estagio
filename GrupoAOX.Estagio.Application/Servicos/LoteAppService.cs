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

        public int_exp_Etiqueta_ProducaoViewModel AtualizarArmazem(int id, string armazem)
        {
            var loteRetorno = Mapper.Map<int_exp_Etiqueta_ProducaoViewModel>(_loteServices.AtualizarArmazem(id, armazem));
            return loteRetorno;
        }

        public int_exp_Etiqueta_ProducaoViewModel AtualizarStatus(int id, StatusViewModel status)
        {
            var loteRetorno = Mapper.Map<int_exp_Etiqueta_ProducaoViewModel>(_loteServices.AtualizarStatus(id, Mapper.Map<Status>(status)));
            return loteRetorno;
        }

        public int_exp_Etiqueta_ProducaoViewModel BiparEtiqueta(string numLote)
        {
            return Mapper.Map<int_exp_Etiqueta_ProducaoViewModel>(_loteServices.BiparEtiqueta(numLote));
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

        public int_exp_Etiqueta_ProducaoViewModel RegistrarRomaneio(int id, string romaneio, string tipoDocumento)
        {
            var loteRetorno = Mapper.Map<int_exp_Etiqueta_ProducaoViewModel>(_loteServices.RegistrarRomaneio(id, romaneio, tipoDocumento));
            if (loteRetorno.ValidationResult.IsValid)
            {
                Commit();
            }
            return loteRetorno;
        }
    }
}
