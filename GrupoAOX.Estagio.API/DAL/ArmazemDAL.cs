using Dapper;
using GrupoAOX.Estagio.API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GrupoAOX.Estagio.API.DAL
{
    public class ArmazemDAL : IDisposable
    {
        public IEnumerable<Armazem> ObterTodos(string filial)
        {
            using (var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Protheus12"]
                .ConnectionString))
            {
                conexao.Open();

                string sql = "";

                if (filial == "5202")
                {
                    sql = "SELECT NNR_FILIAL AS 'Filial', NNR_CODIGO AS 'Codigo', NNR_DESCRI AS 'Descricao', NNR_MSBLQL AS 'Bloqueado'" +
                    "FROM NNR030 WHERE D_E_L_E_T_='' AND NNR_FILIAL = @filial AND NNR_MSBLQL <> '1' " +
                    "AND NNR_CODIGO NOT IN('98','99','DE','EM')";
                }
                else if (filial == "5101")
                {
                    sql = "SELECT NNR_FILIAL AS 'Filial', NNR_CODIGO AS 'Codigo', NNR_DESCRI AS 'Descricao', NNR_MSBLQL AS 'Bloqueado'" +
                    "FROM NNR020 WHERE D_E_L_E_T_='' AND NNR_FILIAL = @filial AND NNR_MSBLQL <> '1' " +
                    "AND NNR_CODIGO NOT IN('98','99','DE','EM')";
                }

                var armazens = conexao.Query<Armazem>(sql, new { @filial = filial });

                return armazens;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}