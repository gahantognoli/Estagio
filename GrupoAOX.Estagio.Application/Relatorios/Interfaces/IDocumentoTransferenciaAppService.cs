using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Relatorios.Interfaces
{
    public interface IDocumentoTransferenciaAppService
    {
        IEnumerable<DocumentoTransferencia> Visualizar(string numDocumento, string tipoDocumento);
    }
}
