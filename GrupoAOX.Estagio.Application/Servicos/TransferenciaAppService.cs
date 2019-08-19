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
    public class TransferenciaAppService : AppService, ITransferenciaAppServices
    {
        private readonly ITransferenciaServices _transferenciaServices;
        private readonly ILoteServices _loteServices;
        private readonly IStatusServices _statusServices;

        public TransferenciaAppService(ITransferenciaServices transferenciaServices,
            ILoteServices loteServices, IStatusServices statusServices, IUnitOfWork uow) : base(uow)
        {
            _transferenciaServices = transferenciaServices;
            _loteServices = loteServices;
            _statusServices = statusServices;
        }

        public TransferenciaViewModel ObterPorId(int id)
        {
            return Mapper.Map<TransferenciaViewModel>(_transferenciaServices.ObterPorId(id));
        }

        public IEnumerable<TransferenciaViewModel> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return Mapper.Map<IEnumerable<TransferenciaViewModel>>(_transferenciaServices.ObterPorPeriodo(dataInicio,
                dataFim));
        }

        public IEnumerable<TransferenciaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TransferenciaViewModel>>(_transferenciaServices.ObterTodos());
        }

        public TransferenciaViewModel Transferir(TransferenciaViewModel transferencia)
        {
            TransferirLotes(transferencia);
            var retornoTransferencia = Mapper.Map<TransferenciaViewModel>(_transferenciaServices
                .Transferir(Mapper.Map<Transferencia>(transferencia)));
            if (retornoTransferencia.ValidationResult.IsValid)
            {
                Commit();
            }
            return retornoTransferencia;
        }

        private void TransferirLotes(TransferenciaViewModel transferencia)
        {
            if (transferencia.Categoria.TipoCategoria == GrupoAox.Estagio.Domain.Enums.TipoCategoria.Romaneio) 
            {
                transferencia.NumeroDocumento = _transferenciaServices.ObterNumDocumento(Mapper.Map<Categoria>
                    (transferencia.Categoria));
                AtualizarLotes(transferencia.Lotes, transferencia.ArmazemDestino, 3, transferencia.NumeroDocumento, "R");
            }
            else if (transferencia.Categoria.TipoCategoria == GrupoAox.Estagio.Domain.Enums.TipoCategoria.OrdemExpedicao)
            {
                _transferenciaServices.ObterNumDocumento(Mapper.Map<Categoria>(transferencia.Categoria));
                AtualizarLotes(transferencia.Lotes, transferencia.ArmazemDestino, 4, transferencia.NumeroDocumento, "O");
            }
        }

        private void AtualizarLotes(ICollection<int_exp_Etiqueta_ProducaoViewModel> lotes,
            string armazem, int status, string romaneio, string tipoDocumento)
        {
            foreach (var item in lotes)
            {
                _loteServices.AtualizarStatus(item.ApontamentoProducaoId, _statusServices.ObterPorId(status));
                _loteServices.AtualizarArmazem(item.ApontamentoProducaoId, armazem);
                _loteServices.RegistrarRomaneio(item.ApontamentoProducaoId, romaneio, tipoDocumento);
            }

        }
    }
}
