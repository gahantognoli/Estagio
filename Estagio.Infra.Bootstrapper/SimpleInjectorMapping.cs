using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Servicos;
using GrupoAOX.Estagio.Data.Contexto;
using GrupoAOX.Estagio.Data.Repositorios;
using GrupoAOX.Estagio.Data.UnitOfWork;
using SimpleInjector;

namespace Estagio.Infra.Bootstrapper
{
    public class SimpleInjectorMapping
    {
        public static void Register(Container container)
        {
            container.Register<ContextoEstagio>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

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
        }
    }
}
