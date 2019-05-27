using Dapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Procedures;
using GrupoAOX.Estagio.Infra.ExtensionMethods;
using Slapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class LogLotesRepositorio : ILogLotesRepositorio
    {
        public IEnumerable<LogLotes> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            IEnumerable<dynamic> query = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                query = dbConnection.Query<dynamic>(LogLotesProcedures.ObterPorPeriodo.GetDescription(), new
                {
                    dataInicio = dataInicio,
                    dataFim = dataFim
                }, commandType: System.Data.CommandType.StoredProcedure);
            }

            AutoMapper.Configuration.AddIdentifier(typeof(LogLotes), "LogLoteId");
            AutoMapper.Configuration.AddIdentifier(typeof(int_exp_Etiqueta_Producao), "ApontamentoProducaoId");

            IEnumerable<LogLotes> logLotes = (AutoMapper.MapDynamic<LogLotes>(query, false) as IEnumerable<LogLotes>);

            return logLotes;
        }

        public IEnumerable<LogLotes> ObterPorUsuario(string usuario)
        {
            IEnumerable<dynamic> query = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                query = dbConnection.Query<dynamic>(LogLotesProcedures.ObterPorUsuario.GetDescription(), new
                {
                    Usuario = usuario
                }, commandType: System.Data.CommandType.StoredProcedure);
            }

            AutoMapper.Configuration.AddIdentifier(typeof(LogLotes), "LogLoteId");
            AutoMapper.Configuration.AddIdentifier(typeof(int_exp_Etiqueta_Producao), "ApontamentoProducaoId");

            IEnumerable<LogLotes> logLotes = (AutoMapper.MapDynamic<LogLotes>(query, false) as IEnumerable<LogLotes>);

            return logLotes;
        }

        public IEnumerable<LogLotes> ObterTodos()
        {
            IEnumerable<dynamic> query = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                query = dbConnection.Query<dynamic>(LogLotesProcedures.ObterTodos.GetDescription(), 
                    commandType: System.Data.CommandType.StoredProcedure);
            }

            AutoMapper.Configuration.AddIdentifier(typeof(LogLotes), "LogLoteId");
            AutoMapper.Configuration.AddIdentifier(typeof(int_exp_Etiqueta_Producao), "ApontamentoProducaoId");

            IEnumerable<LogLotes> logLotes = (AutoMapper.MapDynamic<LogLotes>(query, false) as IEnumerable<LogLotes>);

            return logLotes;
        }
    }
}
