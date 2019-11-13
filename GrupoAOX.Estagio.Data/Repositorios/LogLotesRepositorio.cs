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

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class LogLotesRepositorio : Repositorio<LogLotes>, ILogLotesRepositorio
    {
        public LogLotesRepositorio(ContextoEstagio contexto) : base(contexto)
        {
        }

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

            IEnumerable<LogLotes> logLotes = (AutoMapper.MapDynamic<LogLotes>(query, false) as IEnumerable<LogLotes>);

            return logLotes;
        }

        public IEnumerable<LogLotes> ObterPorUsuario(string usuario)
        {
            IEnumerable<LogLotes> logs = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                logs = dbConnection.Query<LogLotes>(LogLotesProcedures.ObterPorUsuario.GetDescription(),
                    new { @usuario = usuario },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return logs;
        }

        public override IEnumerable<LogLotes> ObterTodos()
        {
            IEnumerable<LogLotes> logs = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                logs = dbConnection.Query<LogLotes>(LogLotesProcedures.ObterTodos.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return logs;
        }
    }
}
