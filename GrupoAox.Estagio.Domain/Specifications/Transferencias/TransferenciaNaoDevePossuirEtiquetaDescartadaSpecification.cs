using DomainValidation.Interfaces.Specification;
using GrupoAox.Estagio.Domain.Entidades;

namespace GrupoAox.Estagio.Domain.Specifications.Transferencias
{
    public class TransferenciaNaoDevePossuirEtiquetaDescartadaSpecification : ISpecification<int_exp_Etiqueta_Producao>
    {
        public bool IsSatisfiedBy(int_exp_Etiqueta_Producao lote)
        {
            return lote.StatusId != 9;
        }
    }
}
