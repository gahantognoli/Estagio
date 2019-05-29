using GrupoAox.Estagio.Domain.Entidades;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface IPermissaoRepositorio : IRepositorio<Permissao>
    {
        Permissao ObterPorDescricao(string descricao);
        Permissao ObterPorSigla(string sigla);
    }
}
