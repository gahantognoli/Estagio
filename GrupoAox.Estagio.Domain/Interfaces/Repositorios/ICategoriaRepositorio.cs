using GrupoAox.Estagio.Domain.Entidades;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Interfaces.Repositorios
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        IEnumerable<Categoria> ObterPorDescricao(string descricao);
    }
}
