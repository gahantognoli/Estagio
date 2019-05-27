using Dapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Contexto;
using GrupoAOX.Estagio.Data.Procedures;
using GrupoAOX.Estagio.Infra.ExtensionMethods;
using Slapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class TransferenciaRepositorio : Repositorio<Transferencia>, ITransferenciaRepositorio
    {
        public TransferenciaRepositorio(ContextoEstagio contextoEstagio) : base(contextoEstagio)
        {
        }

        public override IEnumerable<Transferencia> ObterTodos()
        {
            IEnumerable<dynamic> query = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                query = dbConnection.Query<dynamic>(TransferenciaProcedures.ObterTodos.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure);
            }

            AutoMapper.Configuration.AddIdentifier(typeof(Transferencia), "TransferenciaId");
            AutoMapper.Configuration.AddIdentifier(typeof(int_exp_Etiqueta_Producao), "ApontamentoProducaoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");
            AutoMapper.Configuration.AddIdentifier(typeof(Categoria), "CategoriaId");

            IEnumerable<Transferencia> transferencias = (AutoMapper.MapDynamic<Transferencia>(query, false) as IEnumerable<Transferencia>);

            return transferencias;
        }

        public override Transferencia ObterPorId(int id)
        {
            IEnumerable<dynamic> query = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                query = dbConnection.Query<dynamic>(TransferenciaProcedures.ObterTodos.GetDescription(),
               new
               {
                   id = id
               }, commandType: System.Data.CommandType.StoredProcedure);
            }

            AutoMapper.Configuration.AddIdentifier(typeof(Transferencia), "TransferenciaId");
            AutoMapper.Configuration.AddIdentifier(typeof(int_exp_Etiqueta_Producao), "ApontamentoProducaoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");
            AutoMapper.Configuration.AddIdentifier(typeof(Categoria), "CategoriaId");

            Transferencia transferencia = (AutoMapper.MapDynamic<Transferencia>(query, false) as IEnumerable<Transferencia>).FirstOrDefault();

            return transferencia;
        }


        public IEnumerable<Transferencia> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            IEnumerable<dynamic> query = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                query = dbConnection.Query<dynamic>(TransferenciaProcedures.ObterTodos.GetDescription(),
               new
               {
                   DataInicio = dataInicio,
                   DataFim = dataFim
               }, commandType: System.Data.CommandType.StoredProcedure);
            }

            AutoMapper.Configuration.AddIdentifier(typeof(Transferencia), "TransferenciaId");
            AutoMapper.Configuration.AddIdentifier(typeof(int_exp_Etiqueta_Producao), "ApontamentoProducaoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");
            AutoMapper.Configuration.AddIdentifier(typeof(Categoria), "CategoriaId");

            IEnumerable<Transferencia> transferencias = (AutoMapper.MapDynamic<Transferencia>(query, false) as IEnumerable<Transferencia>);

            return transferencias;
        }

        
        public Transferencia Transferir(Transferencia transferencia)
        {
            Adicionar(transferencia);
            return transferencia;
        }

        public string ObterNumDocumento(Categoria categoria)
        {
            string numeroDocumento = "";
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                numeroDocumento = dbConnection.Query<string>(TransferenciaProcedures.ObterNumeroDocumento.GetDescription(),
                    new { CategoriaId = categoria.CategoriaId }, commandType: System.Data.CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
            return numeroDocumento;
        }
    }
}
