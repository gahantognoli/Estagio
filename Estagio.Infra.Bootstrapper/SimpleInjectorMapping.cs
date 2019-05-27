using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAOX.Estagio.Data.Contexto;
using GrupoAOX.Estagio.Data.Repositorios;
using SimpleInjector;

namespace Estagio.Infra.Bootstrapper
{
    public class SimpleInjectorMapping
    {
        public static void Register(Container container)
        {
            container.Register<ContextoEstagio>(Lifestyle.Scoped);

            //Repository injections
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<ICategoriaRepositorio, CategoriaRepositorio>(Lifestyle.Scoped);
            container.Register<ILogLotesRepositorio, LogLotesRepositorio>(Lifestyle.Scoped);
            container.Register<ILoteRepositorio, LoteRepositorio>(Lifestyle.Scoped);
            container.Register<IPermissaoRepositorio, PermissaoRepositorio>(Lifestyle.Scoped);
            container.Register<IStatusRepositorio, StatusRepositorio>(Lifestyle.Scoped);
            container.Register<ITransferenciaRepositorio, TransferenciaRepositorio>(Lifestyle.Scoped);
        }
    }
}
