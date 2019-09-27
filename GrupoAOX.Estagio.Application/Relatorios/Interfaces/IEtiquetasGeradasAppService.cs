using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Relatorios.Interfaces
{
    public interface IEtiquetasGeradasAppService
    {
        IEnumerable<Etiqueta> ObterEtiquetasGeradas(DateTime dataInicio, DateTime dataFim);
    }
}
