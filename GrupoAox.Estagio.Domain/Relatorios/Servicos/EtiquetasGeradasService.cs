using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Relatorios.Servicos
{
    public class EtiquetasGeradasService : IEtiquetasGeradasService
    {
        private readonly IEtiquetasGeradasRepository _etiquetasGeradasRepository;
        public EtiquetasGeradasService(IEtiquetasGeradasRepository etiquetasGeradasRepository)
        {
            _etiquetasGeradasRepository = etiquetasGeradasRepository;
        }

        public IEnumerable<Etiqueta> ObterEtiquetasGeradas(DateTime dataInicio, DateTime dataFim)
        {
            return _etiquetasGeradasRepository.ObterEtiquetasGeradas(dataInicio, dataFim);
        }
    }
}
