using Dapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Contexto;
using GrupoAOX.Estagio.Data.Procedures;
using GrupoAOX.Estagio.Infra.ExtensionMethods;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class LoteRepositorio : Repositorio<int_exp_Etiqueta_Producao>, ILoteRepositorio
    {
        public LoteRepositorio(ContextoEstagio contextoEstagio) : base(contextoEstagio)
        {
        }

        public int_exp_Etiqueta_Producao AtualizarStatus(int id, Status status)
        {
            int_exp_Etiqueta_Producao lote = ObterPorId(id);
            lote.Status = status;
            Atualizar(lote);
            return lote;
        }

        public override IEnumerable<int_exp_Etiqueta_Producao> ObterTodos()
        {
            IEnumerable<int_exp_Etiqueta_Producao> lotes = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                lotes = dbConnection.Query<int_exp_Etiqueta_Producao>(LoteProcedures.ObterTodos.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return lotes;
        }

        public override int_exp_Etiqueta_Producao ObterPorId(int id)
        {
            int_exp_Etiqueta_Producao lotes = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                lotes = dbConnection.Query<int_exp_Etiqueta_Producao>(LoteProcedures.ObterPorId.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
            return lotes;
        }

        public int_exp_Etiqueta_Producao ObterPorDocumento(string numDocumento)
        {
            int_exp_Etiqueta_Producao lote = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                lote = dbConnection.Query<int_exp_Etiqueta_Producao>(LoteProcedures.ObterPorDocumento.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
            return lote;
        }

        public int_exp_Etiqueta_Producao ObterPorLote(string numLote)
        {
            int_exp_Etiqueta_Producao lote = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                lote = dbConnection.Query<int_exp_Etiqueta_Producao>(LoteProcedures.ObterPorLote.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
            return lote;
        }

        public int_exp_Etiqueta_Producao RegistrarRomaneio(int id, string numRomaneio, string tipoDocumento)
        {
            int_exp_Etiqueta_Producao lote = ObterPorId(id);
            lote.Romaneio = numRomaneio;
            lote.TipoDocumento = tipoDocumento;
            return Atualizar(lote);
        }
    }
}
