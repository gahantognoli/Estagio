using GrupoAox.Estagio.Domain.Relatorios.Entidades;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Relatorios.Servicos
{
    public class MovimentosGeradosService : IMovimentosGeradosService
    {
        private readonly IMovimentosGeradosRepositorio _movimentosGeradosRepositorio;

        public MovimentosGeradosService(IMovimentosGeradosRepositorio movimentosGeradosRepositorio)
        {
            _movimentosGeradosRepositorio = movimentosGeradosRepositorio;
        }

        public IEnumerable<Movimento> ObterPorPeriodo(DateTime dataInicioMovimento, DateTime dataFimMovimento)
        {
            return _movimentosGeradosRepositorio.ObterPorPeriodo(dataInicioMovimento, dataFimMovimento);
        }
    }
}
