﻿using GrupoAOX.Estagio.Data.UnitOfWork;

namespace GrupoAOX.Estagio.Application.Servicos
{
    public class AppService 
    {
        private readonly IUnitOfWork _uow;

        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
