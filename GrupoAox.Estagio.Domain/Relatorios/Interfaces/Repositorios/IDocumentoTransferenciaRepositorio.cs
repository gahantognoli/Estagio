using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios
{
    public interface IDocumentoTransferenciaRepositorio
    {
        IEnumerable<DocumentoTransferencia> Visualizar(string numDocumento, string tipoDocumento);
    }
}
