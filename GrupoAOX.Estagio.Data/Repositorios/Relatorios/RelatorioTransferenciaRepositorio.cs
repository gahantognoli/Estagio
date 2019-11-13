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
    public class RelatorioTransferenciaRepositorio : IRelatorioTransferenciaRepositorio
    {
        public IEnumerable<Transferencia> ObterTransferencias(DateTime dataInicio, DateTime dataFim)
        {
            IEnumerable<Transferencia> transferencias = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                transferencias = dbConnection.Query<Transferencia>(RelatorioTransferenciaProcedures.
                    ObterTransferencias.GetDescription(),
                    new { @DataInicio = dataInicio, @DataFim = dataFim },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return transferencias;
        }
    }
}
