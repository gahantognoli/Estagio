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
    public class EtiquetasGeradasRepository : IEtiquetasGeradasRepository
    {
        public IEnumerable<Etiqueta> ObterEtiquetasGeradas(DateTime dataInicio, DateTime dataFim)
        {
            IEnumerable<Etiqueta> etiquetas = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                etiquetas = dbConnection.Query<Etiqueta>(EtiquetasGeradasProcedures.
                    ObterEtiquetasGeradas.GetDescription(),
                    new { @dataInicio = dataInicio, @dataFim = dataFim },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return etiquetas;
        }
    }
}
