using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Relatorios.Interfaces;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Servicos.Relatorios
{
    public class MovimentosGeradosAppService : IMovimentosGeradosAppService
    {
        private readonly IMovimentosGeradosService _movimentosGeradosService;

        public MovimentosGeradosAppService(IMovimentosGeradosService movimentosGeradosService)
        {
            _movimentosGeradosService = movimentosGeradosService;
        }

        public IEnumerable<Movimento> ObterPorPeriodo(DateTime dataInicioMovimento, DateTime dataFimMovimento)
        {
            return _movimentosGeradosService.ObterPorPeriodo(dataInicioMovimento, dataFimMovimento);
        }
    }
}
