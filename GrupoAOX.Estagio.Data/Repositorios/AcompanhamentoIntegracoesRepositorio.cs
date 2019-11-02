using Dapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Procedures;
using GrupoAOX.Estagio.Infra.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class AcompanhamentoIntegracoesRepositorio : IAcompanhamentoIntegracoesRepositorio
    {
        public IEnumerable<AcompanhamentoIntegracoes> ObterPorData(DateTime dataLancamento)
        {
            IEnumerable<AcompanhamentoIntegracoes> acompanhamentoIntegracoes = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                acompanhamentoIntegracoes = dbConnection.Query<AcompanhamentoIntegracoes>(AcompanhamentoIntegracoesProcedures.ObterTodos.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return acompanhamentoIntegracoes;
        }

        public IEnumerable<AcompanhamentoIntegracoes> ObterPorDocumento(string documento)
        {
            IEnumerable<AcompanhamentoIntegracoes> acompanhamentoIntegracoes = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                acompanhamentoIntegracoes = dbConnection.Query<AcompanhamentoIntegracoes>(AcompanhamentoIntegracoesProcedures.ObterPorDocumento.GetDescription(),
                   new { @Documento = documento }, commandType: System.Data.CommandType.StoredProcedure);
            }
            return acompanhamentoIntegracoes;
        }

        public IEnumerable<AcompanhamentoIntegracoes> ObterPorLote(string lote)
        {
            IEnumerable<AcompanhamentoIntegracoes> acompanhamentoIntegracoes = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                acompanhamentoIntegracoes = dbConnection.Query<AcompanhamentoIntegracoes>(AcompanhamentoIntegracoesProcedures.ObterPorLote.GetDescription(),
                   new { @Lote = lote }, commandType: System.Data.CommandType.StoredProcedure);
            }
            return acompanhamentoIntegracoes;
        }

        public IEnumerable<AcompanhamentoIntegracoes> ObterTodos()
        {
            IEnumerable<AcompanhamentoIntegracoes> acompanhamentoIntegracoes = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                acompanhamentoIntegracoes = dbConnection.Query<AcompanhamentoIntegracoes>(AcompanhamentoIntegracoesProcedures.ObterTodos.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return acompanhamentoIntegracoes;
        }
    }
}
