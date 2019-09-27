using Dapper;
using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Procedures;
using GrupoAOX.Estagio.Data.Procedures.Relatorios;
using GrupoAOX.Estagio.Infra.ExtensionMethods;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace GrupoAOX.Estagio.Data.Repositorios.Relatorios
{
    public class DocumentoTransferenciaRepositorio : IDocumentoTransferenciaRepositorio
    {
        public IEnumerable<DocumentoTransferencia> Visualizar(string numDocumento, string tipoDocumento)
        {
            IEnumerable<DocumentoTransferencia> documentoTransferencias = null;
            using (DbConnection dbConnection = new SqlConnection(ConexaoBancoDeDados.ObterStringConexao()))
            {
                documentoTransferencias = dbConnection.Query<DocumentoTransferencia>(DocumentoTransferenciaProcedures.
                    ImpressaoDocumentoTransferencia.GetDescription(),
                    new { @numDocumento = numDocumento, @tipoDocumento = tipoDocumento },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
            return documentoTransferencias;
        }
    }
}
