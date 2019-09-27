using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Validations.Transferencias;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class TransferenciaServices : ITransferenciaServices
    {
        private readonly ITransferenciaRepositorio _transferenciaRepositorio;
        private readonly ILogLotesRepositorio _logLotesRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public TransferenciaServices(ITransferenciaRepositorio transferenciaRepositorio, 
            ILogLotesRepositorio logLotesRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
            _logLotesRepositorio = logLotesRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Transferencia ObterPorId(int id)
        {
            return _transferenciaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Transferencia> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _transferenciaRepositorio.ObterPorPeriodo(dataInicio, dataFim);
        }

        public IEnumerable<Transferencia> ObterTodos()
        {
            return _transferenciaRepositorio.ObterTodos();
        }

        public Transferencia Transferir(Transferencia transferencia)
        {
            transferencia.ValidationResult = new TransferenciaAptaParaCadastro().Validate(transferencia);
            if (!transferencia.ValidationResult.IsValid)
            {
                return transferencia;
            }
            else
            {
                var transferenciaRetorno = _transferenciaRepositorio.Transferir(transferencia);
                foreach (var lote in transferencia.Lotes)
                {
                    var log = new LogLotes()
                    {
                        ApontamentoProducaoId = lote.ApontamentoProducaoId,
                        Data = DateTime.Now,
                        Usuario = transferencia.UsuarioId.ToString()
                    };
                    _logLotesRepositorio.Adicionar(log);
                }
                return transferencia;
            }
        }

        public void Dispose()
        {
            _transferenciaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public string ObterNumDocumento()
        {
            return _transferenciaRepositorio.ObterNumDocumento();
        }
    }
}
