using DomainValidation.Interfaces.Specification;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;

namespace GrupoAox.Estagio.Domain.Specifications.Permissoes
{
    public class PermissaoDevePossuirSiglaUnicaSpecification : ISpecification<Permissao>
    {
        private readonly IPermissaoRepositorio _permissaoRepositorio;

        public PermissaoDevePossuirSiglaUnicaSpecification(IPermissaoRepositorio permissaoRepositorio)
        {
            _permissaoRepositorio = permissaoRepositorio;
        }

        public bool IsSatisfiedBy(Permissao permissao)
        {
            return _permissaoRepositorio.ObterPorSigla(permissao.Sigla.Trim()) == null;
        }
    }
}
