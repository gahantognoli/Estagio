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
        private readonly ICategoriaAppServices _categoriaAppServices;

        public TransferenciaAppService(ITransferenciaServices transferenciaServices,
            ILoteServices loteServices, IStatusServices statusServices,
            ICategoriaAppServices categoriaAppServices, IUnitOfWork uow) : base(uow)
        {
            _transferenciaServices = transferenciaServices;
            _loteServices = loteServices;
            _statusServices = statusServices;
            _categoriaAppServices = categoriaAppServices;
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
            var categoria = _categoriaAppServices.ObterPorId(transferencia.CategoriaId);
            if (categoria.Descricao == "Romaneio") 
            {
                transferencia.Lotes = AtualizarLotes(transferencia.Lotes, transferencia.ArmazemDestino, 3, transferencia.NumeroDocumento, "R");
            }
            else if (categoria.Descricao == "Ordem de Expedição")
            {
                transferencia.Lotes = AtualizarLotes(transferencia.Lotes, transferencia.ArmazemDestino, 4, transferencia.NumeroDocumento, "O");
            }
        }

        private ICollection<int_exp_Etiqueta_ProducaoViewModel> AtualizarLotes(ICollection<int_exp_Etiqueta_ProducaoViewModel> lotes,
            string armazem, int status, string romaneio, string tipoDocumento)
        {
            List<int_exp_Etiqueta_Producao> lotesRetorno = new List<int_exp_Etiqueta_Producao>();
            foreach (var item in lotes)
            {
                var lote = _loteServices.ObterPorId(item.ApontamentoProducaoId);
                lote.Armazem = armazem;
                lote.StatusId = status;
                lote.Romaneio = romaneio;
                lote.TipoDocumento = tipoDocumento;
                lotesRetorno.Add(lote);
            }
            lotes = Mapper.Map<ICollection<int_exp_Etiqueta_ProducaoViewModel>>(lotesRetorno);
            return lotes;
        }

        public void Dispose()
        {
            _loteServices.Dispose();
            _statusServices.Dispose();
            _transferenciaServices.Dispose();
        }

        public string ObterNumDocumento()
        {
            return _transferenciaServices.ObterNumDocumento();
        }

        public IEnumerable<TransferenciaViewModel> ObterTodos(string categoria)
        {
            return Mapper.Map<IEnumerable<TransferenciaViewModel>>(_transferenciaServices.ObterTodos(categoria));
        }

        public IEnumerable<TransferenciaViewModel> ObterPorNumDocumento(string numDocumento, string categoria)
        {
            return Mapper.Map<IEnumerable<TransferenciaViewModel>>(_transferenciaServices.ObterPorNumDocumento(numDocumento, categoria));
        }

        public IEnumerable<TransferenciaViewModel> ObterPorData(DateTime data, string categoria)
        {
            return Mapper.Map<IEnumerable<TransferenciaViewModel>>(_transferenciaServices.ObterPorData(data, categoria));
        }

        public IEnumerable<TransferenciaViewModel> ObterPorUsuario(string usuario, string categoria)
        {
            return Mapper.Map<IEnumerable<TransferenciaViewModel>>(_transferenciaServices.ObterPorUsuario(usuario, categoria));
        }
    }
}
