using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Relatorios.Servicos
{
    public class DocumentoTransferenciaService : IDocumentoTransferenciaService
    {
        private readonly IDocumentoTransferenciaRepositorio _documentoTransferenciaRepositorio;

        public DocumentoTransferenciaService(IDocumentoTransferenciaRepositorio documentoTransferenciaRepositorio)
        {
            _documentoTransferenciaRepositorio = documentoTransferenciaRepositorio;
        }

        public IEnumerable<DocumentoTransferencia> Visualizar(string numDocumento, string tipoDocumento)
        {
            return _documentoTransferenciaRepositorio.Visualizar(numDocumento, tipoDocumento);
        }
    }
}
