using Dapper;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Procedures;
using GrupoAOX.Estagio.Infra.ExtensionMethods;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class DashboardRepositorio : IDashboardRepositorio
    {
        public int ObterLotesAguardandoIntegracao()
        {
            int lote;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                lote = dbConnection.Query<int>(DashboardProcedures.ObterAguardandoIntegracao.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
            return lote;
        }

        public int ObterLotesFalhaIntegracao()
        {
            int lote;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                lote = dbConnection.Query<int>(DashboardProcedures.ObterFalhaIntegracao.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
            return lote;
        }

        public int ObterLotesIntegrados()
        {
            int lote;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                lote = dbConnection.Query<int>(DashboardProcedures.ObterIntegrados.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
            return lote;
        }
    }
}
