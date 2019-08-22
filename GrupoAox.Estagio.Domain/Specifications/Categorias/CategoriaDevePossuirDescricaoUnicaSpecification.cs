using DomainValidation.Interfaces.Specification;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using System.Linq;

namespace GrupoAox.Estagio.Domain.Specifications.Categorias
{
    public class CategoriaDevePossuirDescricaoUnicaSpecification : ISpecification<Categoria>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaDevePossuirDescricaoUnicaSpecification(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public bool IsSatisfiedBy(Categoria categoria)
        {
            return _categoriaRepositorio.ObterPorDescricao(categoria.Descricao.Trim()).Count() == 0;
        }
    }
}
