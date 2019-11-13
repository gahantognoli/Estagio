using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Relatorios.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Relatorios.Servicos;
using GrupoAox.Estagio.Domain.Servicos;
using GrupoAOX.Estagio.Application.Interfaces;
using GrupoAOX.Estagio.Application.Relatorios.Interfaces;
using GrupoAOX.Estagio.Application.Servicos;
using GrupoAOX.Estagio.Application.Servicos.Relatorios;
using GrupoAOX.Estagio.Application.ViewModel;
using GrupoAOX.Estagio.Data.Contexto;
using GrupoAOX.Estagio.Data.Repositorios;
using GrupoAOX.Estagio.Data.Repositorios.Relatorios;
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
            container.Register<IDocumentoTransferenciaRepositorio, DocumentoTransferenciaRepositorio>(Lifestyle.Scoped);
            container.Register<IEtiquetasGeradasRepository, EtiquetasGeradasRepository>(Lifestyle.Scoped);
            container.Register<IMovimentosGeradosRepositorio, MovimentosGeradosRepositorio>(Lifestyle.Scoped);
            container.Register<IAcompanhamentoIntegracoesRepositorio, AcompanhamentoIntegracoesRepositorio>(Lifestyle.Scoped);
            container.Register<ILembreteRepositorio, LembreteRepositorio>(Lifestyle.Scoped);
            container.Register<IDashboardRepositorio, DashboardRepositorio>(Lifestyle.Scoped);
            container.Register<IRelatorioTransferenciaRepositorio, RelatorioTransferenciaRepositorio>(Lifestyle.Scoped);

            //Services injections
            container.Register<IUsuarioServices, UsuarioServices>(Lifestyle.Scoped);
            container.Register<ICategoriaServices, CategoriaServices>(Lifestyle.Scoped);
            container.Register<ILogLotesServices, LogLotesServices>(Lifestyle.Scoped);
            container.Register<ILoteServices, LoteServices>(Lifestyle.Scoped);
            container.Register<IPermissaoServices, PermissaoServices>(Lifestyle.Scoped);
            container.Register<IStatusServices, StatusServices>(Lifestyle.Scoped);
            container.Register<ITransferenciaServices, TransferenciaServices>(Lifestyle.Scoped);
            container.Register<IDocumentoTransferenciaService, DocumentoTransferenciaService>(Lifestyle.Scoped);
            container.Register<IEtiquetasGeradasService, EtiquetasGeradasService>(Lifestyle.Scoped);
            container.Register<IMovimentosGeradosService, MovimentosGeradosService>(Lifestyle.Scoped);
            container.Register<IAcompanhamentoIntegracoesServices, AcompanhamentoIntegracoesServices>(Lifestyle.Scoped);
            container.Register<ILembreteService, LembreteService>(Lifestyle.Scoped);
            container.Register<IDashboardServices, DashboardServices>(Lifestyle.Scoped);
            container.Register<IRelatorioTransferenciaServices, RelatorioTransferenciaServices>(Lifestyle.Scoped);

            //App Services 
            container.Register<IUsuarioAppServices, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<ICategoriaAppServices, CategoriaAppService>(Lifestyle.Scoped);
            container.Register<ILogLotesAppServices, LogLotesAppService>(Lifestyle.Scoped);
            container.Register<ILoteAppServices, LoteAppService>(Lifestyle.Scoped);
            container.Register<IPermissaoAppServices, PermissaoAppService>(Lifestyle.Scoped);
            container.Register<IStatusAppServices, StatusAppService>(Lifestyle.Scoped);
            container.Register<ITransferenciaAppServices, TransferenciaAppService>(Lifestyle.Scoped);
            container.Register<IDocumentoTransferenciaAppService, DocumentoTransferenciaAppService>(Lifestyle.Scoped);
            container.Register<IEtiquetasGeradasAppService, EtiquetasGeradasAppService>(Lifestyle.Scoped);
            container.Register<IMovimentosGeradosAppService, MovimentosGeradosAppService>(Lifestyle.Scoped);
            container.Register<IAcompanhamentoIntegracoesAppServices, AcompanhamentoIntegracoesAppServices>(Lifestyle.Scoped);
            container.Register<ILembreteAppService, LembreteAppService>(Lifestyle.Scoped);
            container.Register<IDashboardAppServices, DashboardAppServices>(Lifestyle.Scoped);
            container.Register<IRelatorioTransferenciaAppServices, RelatorioTransferenciaAppServices>(Lifestyle.Scoped);

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
