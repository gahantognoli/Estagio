using GrupoAox.Estagio.Domain.Entidades;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface IPermissaoRepositorio : IRepositorio<Permissao>
    {
        IEnumerable<Permissao> ObterPorDescricao(string descricao);
        Permissao ObterPorSigla(string sigla);
    }
}
