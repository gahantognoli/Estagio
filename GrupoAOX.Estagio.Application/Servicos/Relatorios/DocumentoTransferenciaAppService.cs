using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Relatorios.Interfaces;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Servicos.Relatorios
{
    public class DocumentoTransferenciaAppService : IDocumentoTransferenciaAppService
    {
        private readonly IDocumentoTransferenciaService _documentoTransferenciaService;
        public DocumentoTransferenciaAppService(IDocumentoTransferenciaService documentoTransferenciaService)
        {
            _documentoTransferenciaService = documentoTransferenciaService;
        }

        public IEnumerable<DocumentoTransferencia> Visualizar(string numDocumento, string tipoDocumento)
        {
            return _documentoTransferenciaService.Visualizar(numDocumento, tipoDocumento);
        }
    }
}
