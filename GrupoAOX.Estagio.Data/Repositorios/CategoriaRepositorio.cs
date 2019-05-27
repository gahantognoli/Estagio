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
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(ContextoEstagio contexto) : base(contexto)
        {
        }

        public override IEnumerable<Categoria> ObterTodos()
        {
            IEnumerable<Categoria> categoria = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                categoria = dbConnection.Query<Categoria>(CategoriaProcedures.ObterTodos.GetDescription(), 
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return categoria;
        }

        public override Categoria ObterPorId(int id)
        {
            Categoria categoria = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                categoria = dbConnection.Query<Categoria>(CategoriaProcedures.ObterPorId.GetDescription(), new
                {
                    id = id
                }, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
            return categoria;
        }
    }
}
