using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos
{
    public interface IDocumentoTransferenciaService
    {
        IEnumerable<DocumentoTransferencia> Visualizar(string numDocumento, string tipoDocumento);
    }
}
