using Dapper;
using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Procedures;
using GrupoAOX.Estagio.Data.Procedures.Relatorios;
using GrupoAOX.Estagio.Infra.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace GrupoAOX.Estagio.Data.Repositorios.Relatorios
{
    public class MovimentosGeradosRepositorio : IMovimentosGeradosRepositorio
    {
        public IEnumerable<Movimento> ObterPorPeriodo(DateTime dataInicioMovimento, DateTime dataFimMovimento)
        {
            IEnumerable<Movimento> documentoTransferencias = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                documentoTransferencias = dbConnection.Query<Movimento>(MovimentosGeradosProcedures
                    .ObterMovimentosPorPeriodo.GetDescription(),
                    new { @DataMovimentoInicio = dataInicioMovimento, @DataMovimentoFim = dataFimMovimento },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return documentoTransferencias;
        }
    }
}
