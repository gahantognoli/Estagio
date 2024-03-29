﻿using Dapper;
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
    public class StatusRepositorio : Repositorio<Status>, IStatusRepositorio
    {
        public StatusRepositorio(ContextoEstagio contextoEstagio) : base(contextoEstagio)
        {
        }

        public override IEnumerable<Status> ObterTodos()
        {
            IEnumerable<Status> status = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                status = dbConnection.Query<Status>(StatusProcedures.ObterTodos.GetDescription(), commandType: 
                    System.Data.CommandType.StoredProcedure);
            }
            return status;
        }

        public override Status ObterPorId(int id)
        {
            Status status = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                status = dbConnection.Query<Status>(StatusProcedures.ObterPorId.GetDescription(), new
                {
                    id = id
                },
                commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
            return status;
        }

        public IEnumerable<Status> ObterPorDescricao(string descricao)
        {
            IEnumerable<Status> status = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                status = dbConnection.Query<Status>(StatusProcedures.ObterPorDescricao.GetDescription(), 
                    new { descricao = descricao }, commandType: System.Data.CommandType.StoredProcedure);
            }
            return status;
        }

        public override void Remover(int id)
        {
            var status = ObterPorId(id);
            status.Deletado = true;
            Atualizar(status);
        }
    }
}
