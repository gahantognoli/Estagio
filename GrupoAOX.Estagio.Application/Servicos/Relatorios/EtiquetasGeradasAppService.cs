using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Relatorios.Interfaces;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Servicos.Relatorios
{
    public class EtiquetasGeradasAppService : IEtiquetasGeradasAppService
    {
        private readonly IEtiquetasGeradasService _etiquetasGeradasService;
        public EtiquetasGeradasAppService(IEtiquetasGeradasService etiquetasGeradasService)
        {
            _etiquetasGeradasService = etiquetasGeradasService;
        }
        public IEnumerable<Etiqueta> ObterEtiquetasGeradas(DateTime dataInicio, DateTime dataFim)
        {
            return _etiquetasGeradasService.ObterEtiquetasGeradas(dataInicio, dataFim);
        }
    }
}
