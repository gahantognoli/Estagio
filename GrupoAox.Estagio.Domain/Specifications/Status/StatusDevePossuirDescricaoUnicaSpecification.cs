using DomainValidation.Interfaces.Specification;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using System.Linq;

namespace GrupoAox.Estagio.Domain.Specifications.Status
{
    public class StatusDevePossuirDescricaoUnicaSpecification : ISpecification<Estagio.Domain.Entidades.Status>
    {
        private readonly IStatusRepositorio _statusRepositorio;
        public StatusDevePossuirDescricaoUnicaSpecification(IStatusRepositorio statusRepositorio)
        {
            _statusRepositorio = statusRepositorio;
        }

        public bool IsSatisfiedBy(Entidades.Status status)
        {
            return _statusRepositorio.ObterPorDescricao(status.Descricao).Count() == 0;
        }
    }
}
