using AutoMapper;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace GrupoAOX.Estagio.Application.Servicos
{
    public class LogLotesAppService : AppService, ILogLotesAppServices
    {
        private readonly ILogLotesServices _logLotesServices;

        public LogLotesAppService(ILogLotesServices logLotesServices, IUnitOfWork uow) : base(uow)
        {
            _logLotesServices = logLotesServices;
        }

        public IEnumerable<LogLotesViewModel> ObterPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return Mapper.Map<IEnumerable<LogLotesViewModel>>(_logLotesServices.ObterPorPeriodo(dataInicio, dataFim));
        }

        public IEnumerable<LogLotesViewModel> ObterPorUsuario(string usuario)
        {
            return Mapper.Map<IEnumerable<LogLotesViewModel>>(_logLotesServices.ObterPorUsuario(usuario));
        }

        public IEnumerable<LogLotesViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<LogLotesViewModel>>(_logLotesServices.ObterTodos());
        }
    }
}
