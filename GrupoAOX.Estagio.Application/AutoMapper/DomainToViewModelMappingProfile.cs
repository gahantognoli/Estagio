using AutoMapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAOX.Estagio.Application.ViewModel;

namespace GrupoAOX.Estagio.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Permissao, PermissaoViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Status, StatusViewModel>();
            CreateMap<Transferencia, TransferenciaViewModel>();
            CreateMap<LogLotes, LogLotesViewModel>();
            CreateMap<int_exp_Etiqueta_Producao, int_exp_Etiqueta_ProducaoViewModel>();
            CreateMap<AcompanhamentoIntegracoes, AcompanhamentoIntegracoesViewModel>();
            CreateMap<Lembrete, LembreteViewModel>();
        }
    }
}
