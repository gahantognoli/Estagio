using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Contexto;
using GrupoAOX.Estagio.Data.Procedures;
using GrupoAOX.Estagio.Infra.ExtensionMethods;
using Slapper;

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class PermissaoRepositorio : Repositorio<Permissao>, IPermissaoRepositorio
    {
        public PermissaoRepositorio(ContextoEstagio contexto):base(contexto)
        {
        }

        public override IEnumerable<Permissao> ObterTodos()
        {
            IEnumerable<Permissao> permissoes = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                permissoes = dbConnection.Query<Permissao>(PermissaoProcedures.ObterTodos.GetDescription(),
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return permissoes;
        }

        public override Permissao ObterPorId(int id)
        {
            IEnumerable<dynamic> query = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                query = dbConnection.Query<dynamic>(PermissaoProcedures.ObterPorId.GetDescription(), new
                {
                    id = id
                }, commandType: System.Data.CommandType.StoredProcedure);
            }

            AutoMapper.Configuration.AddIdentifier(typeof(Permissao), "PermissaoId");
            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");

            Permissao permissao = (AutoMapper.MapDynamic<Permissao>(query, false) as IEnumerable<Permissao>).FirstOrDefault();

            return permissao;
        }
    }
}
