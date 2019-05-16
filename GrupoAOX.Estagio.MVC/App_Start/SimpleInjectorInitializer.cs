[assembly: WebActivator.PostApplicationStartMethod(typeof(GrupoAOX.Estagio.MVC.App_Start.SimpleInjectorInitializer), 
    "Initialize")]

namespace GrupoAOX.Estagio.MVC.App_Start
{
    using global::Estagio.Infra.Bootstrapper;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Reflection;
    using System.Web.Mvc;

    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultLifestyle = new WebRequestLifestyle();
            InitializeContainer(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            SimpleInjectorMapping.Register(container);
        }
    }
}