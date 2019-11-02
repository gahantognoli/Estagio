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
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public TransferenciaServices(ITransferenciaRepositorio transferenciaRepositorio, 
            ILogLotesRepositorio logLotesRepositorio, IUsuarioRepositorio usuarioRepositorio,
            ICategoriaRepositorio categoriaRepositorio)
        {
            _transferenciaRepositorio = transferenciaRepositorio;
            _logLotesRepositorio = logLotesRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
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
                        Usuario = transferencia.UsuarioId.ToString(),
                        OrdemProducao = lote.OrderProducao,
                        Etiqueta = lote.Etiqueta,
                        Armazem = transferencia.ArmazemDestino,
                        NumDocumento = transferencia.NumeroDocumento,
                        Acao = _categoriaRepositorio.ObterPorId(transferencia.CategoriaId).Descricao
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

        public IEnumerable<Transferencia> ObterTodos(string categoria)
        {
            return _transferenciaRepositorio.ObterTodos(categoria);
        }

        public IEnumerable<Transferencia> ObterPorNumDocumento(string numDocumento, string categoria)
        {
            return _transferenciaRepositorio.ObterPorNumDocumento(numDocumento, categoria);
        }

        public IEnumerable<Transferencia> ObterPorData(DateTime data, string categoria)
        {
            return _transferenciaRepositorio.ObterPorData(data, categoria);
        }

        public IEnumerable<Transferencia> ObterPorUsuario(string usuario, string categoria)
        {
            return _transferenciaRepositorio.ObterPorUsuario(usuario, categoria);
        }
    }
}
