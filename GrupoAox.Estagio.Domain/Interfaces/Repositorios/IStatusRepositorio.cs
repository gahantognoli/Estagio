using GrupoAox.Estagio.Domain.Entidades;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface IStatusRepositorio : IRepositorio<Status>
    {
        IEnumerable<Status> ObterPorDescricao(string descricao);
    }
}
