using DomainValidation.Interfaces.Specification;
using GrupoAox.Estagio.Domain.Entidades;
using System.Linq;

namespace GrupoAox.Estagio.Domain.Specifications.Transferencias
{
    public class TransferenciaDevePossuirLotesSpecification : ISpecification<Transferencia>
    {
        public bool IsSatisfiedBy(Transferencia transferencia)
        {
            return transferencia.Lotes.Count() > 0;
        }
    }
}
