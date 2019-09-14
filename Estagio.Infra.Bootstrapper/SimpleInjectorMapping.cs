using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Servicos;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.Servicos;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.Data.Contexto;
using GrupoAOX.Estagio.Data.Repositorios;
using GrupoAOX.Estagio.Data.UnitOfWork;
using GrupoAOX.Estagio.Infra.Serializacao.Servicos;
using SimpleInjector;
using System.Collections.Generic;

namespace Estagio.Infra.Bootstrapper
{
    public class SimpleInjectorMapping
    {
        public static void Register(Container container)
        {
            //Repository injections
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<ICategoriaRepositorio, CategoriaRepositorio>(Lifestyle.Scoped);
            container.Register<ILogLotesRepositorio, LogLotesRepositorio>(Lifestyle.Scoped);
            container.Register<ILoteRepositorio, LoteRepositorio>(Lifestyle.Scoped);
            container.Register<IPermissaoRepositorio, PermissaoRepositorio>(Lifestyle.Scoped);
            container.Register<IStatusRepositorio, StatusRepositorio>(Lifestyle.Scoped);
            container.Register<ITransferenciaRepositorio, TransferenciaRepositorio>(Lifestyle.Scoped);


            //Services injections
            container.Register<IUsuarioServices, UsuarioServices>(Lifestyle.Scoped);
            container.Register<ICategoriaServices, CategoriaServices>(Lifestyle.Scoped);
            container.Register<ILogLotesServices, LogLotesServices>(Lifestyle.Scoped);
            container.Register<ILoteServices, LoteServices>(Lifestyle.Scoped);
            container.Register<IPermissaoServices, PermissaoServices>(Lifestyle.Scoped);
            container.Register<IStatusServices, StatusServices>(Lifestyle.Scoped);
            container.Register<ITransferenciaServices, TransferenciaServices>(Lifestyle.Scoped);

            //App Services 
            container.Register<IUsuarioAppServices, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<ICategoriaAppServices, CategoriaAppService>(Lifestyle.Scoped);
            container.Register<ILogLotesAppServices, LogLotesAppService>(Lifestyle.Scoped);
            container.Register<ILoteAppServices, LoteAppService>(Lifestyle.Scoped);
            container.Register<IPermissaoAppServices, PermissaoAppService>(Lifestyle.Scoped);
            container.Register<IStatusAppServices, StatusAppService>(Lifestyle.Scoped);
            container.Register<ITransferenciaAppServices, TransferenciaAppService>(Lifestyle.Scoped);

            container.Register<IEntitySerializationServices<UsuarioViewModel>, 
                JSONSerializationServices<UsuarioViewModel>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<TransferenciaViewModel>,
                JSONSerializationServices<TransferenciaViewModel>>(Lifestyle.Scoped);
            container.Register<IEntitySerializationServices<IEnumerable<int_exp_Etiqueta_ProducaoViewModel>>,
                JSONSerializationServices<IEnumerable<int_exp_Etiqueta_ProducaoViewModel>>>(Lifestyle.Scoped);

            container.Register<ContextoEstagio>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}
