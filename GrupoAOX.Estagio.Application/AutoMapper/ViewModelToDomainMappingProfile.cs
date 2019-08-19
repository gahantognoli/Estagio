using AutoMapper;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAOX.Estagio.Application.ViewModel;

namespace GrupoAOX.Estagio.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CategoriaViewModel, Categoria>();
            CreateMap<PermissaoViewModel, Permissao>();
            CreateMap<StatusViewModel, Status>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<TransferenciaViewModel, Transferencia>();
            CreateMap<LogLotesViewModel, LogLotes>();
            CreateMap<int_exp_Etiqueta_ProducaoViewModel, int_exp_Etiqueta_Producao>();
        }
    }
}
