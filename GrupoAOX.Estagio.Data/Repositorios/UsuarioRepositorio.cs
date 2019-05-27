using Dapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Contexto;
using GrupoAOX.Estagio.Data.Procedures;
using GrupoAOX.Estagio.Infra.ExtensionMethods;
using Slapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ContextoEstagio contexto):base(contexto)
        {
        }

        public override IEnumerable<Usuario> ObterTodos()
        {
            IEnumerable<Usuario> usuario = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                usuario = dbConnection.Query<Usuario>(UsuarioProcedures.ObterTodos.GetDescription(),
                commandType: System.Data.CommandType.StoredProcedure);
            }
            return usuario;
        }

        public override Usuario ObterPorId(int id)
        {
            IEnumerable<dynamic> query = null;

            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                query = dbConnection.Query<Usuario>(UsuarioProcedures.ObterPorId.GetDescription(), new {
                    id = id
                }, commandType: System.Data.CommandType.StoredProcedure);
            }

            AutoMapper.Configuration.AddIdentifier(typeof(Usuario), "UsuarioId");
            AutoMapper.Configuration.AddIdentifier(typeof(Permissao), "PermissaoId");

            Usuario usuario = (AutoMapper.MapDynamic<Usuario>(query, false) as IEnumerable<Usuario>).FirstOrDefault();

            return usuario;
        }

        public Usuario ObterPorLogin(string login)
        {
            return Buscar(u => u.Login == login && u.Ativo == true).FirstOrDefault();
        }

        public Usuario ObterPorEmail(string email)
        {
            return Buscar(u => u.Email == email).FirstOrDefault();
        }

        public override Usuario Atualizar(Usuario obj)
        {
            Usuario usuarioExistente = Db.Usuarios.Include("Permissoes")
                .Where(e => e.UsuarioId == obj.UsuarioId).FirstOrDefault();

            List<Permissao> permissoesParaDeletar = usuarioExistente.Permissoes.Except(obj.Permissoes,
                p => p.PermissaoId).ToList();

            List<Permissao> permissoesParaAdicionar = usuarioExistente.Permissoes.Except(usuarioExistente.Permissoes,
                p => p.PermissaoId).ToList();

            permissoesParaDeletar.ForEach(p => usuarioExistente.Permissoes.Remove(p));

            foreach (Permissao p in permissoesParaAdicionar)
            {
                if (Db.Entry(p).State == System.Data.Entity.EntityState.Detached)
                {
                    Db.Permissoes.Attach(p);
                }
                usuarioExistente.Permissoes.Add(p);
            }

            return usuarioExistente;
        }

        public override void Remover(int id)
        {
            var usuario = ObterPorId(id);
            usuario.Ativo = false;
            Atualizar(usuario);
        }

        public void SalvarImagem(int id, string caminhoImagem)
        {
            var usuario = ObterPorId(id);
            usuario.CaminhoImg = caminhoImagem;
            Atualizar(usuario);
        }
    }
}
