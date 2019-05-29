using GrupoAox.Estagio.Domain.Interfaces.Repositorios;

namespace GrupoAox.Estagio.Domain.Specifications.Status
{
    public class StatusDevePossuirIdUnicoSpecification : DomainValidation.Interfaces.Specification.ISpecification
        <GrupoAox.Estagio.Domain.Entidades.Status>
    {
        private readonly IStatusRepositorio _statusRepositorio;

        public StatusDevePossuirIdUnicoSpecification(IStatusRepositorio statusRepositorio)
        {
            _statusRepositorio = statusRepositorio;
        }

        public bool IsSatisfiedBy(GrupoAox.Estagio.Domain.Entidades.Status status)
        {
            return _statusRepositorio.ObterPorId(status.StatusId) == null;
        }
    }
}
