using GrupoAOX.Estagio.Data.Contexto;
using SimpleInjector;

namespace Estagio.Infra.Bootstrapper
{
    public class SimpleInjectorMapping
    {
        public static void Register(Container container)
        {
            container.Register<ContextoEstagio>(Lifestyle.Scoped);
        }
    }
}
