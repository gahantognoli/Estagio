using DomainValidation.Validation;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Specifications.Transferencias;

namespace GrupoAox.Estagio.Domain.Validations.Lotes
{
    public class LoteAptoParaCadastroValidation : Validator<int_exp_Etiqueta_Producao>
    {
        public LoteAptoParaCadastroValidation()
        {
            var loteComEtiquetaDescartada = new TransferenciaNaoDevePossuirEtiquetaDescartadaSpecification();

            base.Add("loteComEtiquetaDescartada", new Rule<int_exp_Etiqueta_Producao>(loteComEtiquetaDescartada, 
                "A Etiqueta está descartada"));
        }
    }
}
