using DomainValidation.Interfaces.Specification;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using System.Linq;

namespace GrupoAox.Estagio.Domain.Specifications.Permissoes
{
    public class PermissaoDevePossuirDescricaoUnicaSpecification : ISpecification<Permissao>
    {
        private readonly IPermissaoRepositorio _permissaoRepositorio;

        public PermissaoDevePossuirDescricaoUnicaSpecification(IPermissaoRepositorio permissaoRepositorio)
        {
            _permissaoRepositorio = permissaoRepositorio;
        }

        public bool IsSatisfiedBy(Permissao permissao)
        {
            return _permissaoRepositorio.ObterPorDescricao(permissao.Descricao.Trim()).Count() == 0;
        }
    }
}
