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
using System.Linq;

namespace GrupoAOX.Estagio.Data.Repositorios
{
    public class LembreteRepositorio : Repositorio<Lembrete>, ILembreteRepositorio
    {
        public LembreteRepositorio(ContextoEstagio contextoEstagio) : base(contextoEstagio)
        {
        }

        public IEnumerable<Lembrete> ObterPorDataLancamento(DateTime dataLancamento, int usuarioId)
        {
            IEnumerable<Lembrete> lembretes = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                lembretes = dbConnection.Query<Lembrete>(LembretesProcedures.ObterPorDataLancamento.GetDescription(),
                    new { @usuarioId = usuarioId, @dataLancamento = dataLancamento },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return lembretes;
        }

        public override Lembrete ObterPorId(int id)
        {
            IEnumerable<dynamic> query = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                query = dbConnection.Query<dynamic>(LembretesProcedures.ObterPorId.GetDescription(), new
                {
                    @lembreteId = id
                }, commandType: System.Data.CommandType.StoredProcedure);
            }

            AutoMapper.Configuration.AddIdentifier(typeof(Transferencia), "NumeroDocumento");
            AutoMapper.Configuration.AddIdentifier(typeof(int_exp_Etiqueta_Producao), "ApontamentoProducaoId");

            Lembrete lembrete = (AutoMapper.MapDynamic<Lembrete>(query, false) as IEnumerable<Lembrete>).FirstOrDefault();

            return lembrete;
        }

        public IEnumerable<Lembrete> ObterTodos(int usuarioId)
        {
            IEnumerable<Lembrete> lembretes = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                lembretes = dbConnection.Query<Lembrete>(LembretesProcedures.ObterTodos.GetDescription(),
                    new { @usuarioId = usuarioId },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return lembretes;
        }

        public override Lembrete Atualizar(Lembrete obj)
        {
            var lembrete = Db.Lembretes.Find(obj.LembreteId);
            lembrete.Descricao = obj.Descricao;
            return obj;
        }

        public override void Remover(int id)
        {
            var lembrete = Db.Lembretes.Find(id);
            lembrete.Deletado = true;
        }

        public void MarcarConclusao(int lembreteId, bool concluido)
        {
            var lembrete = Db.Lembretes.Find(lembreteId);
            lembrete.Concluido = concluido;
        }
    }
}
