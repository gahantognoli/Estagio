using DomainValidation.Validation;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Specifications.Transferencias;

namespace GrupoAox.Estagio.Domain.Validations.Transferencias
{
    public class TransferenciaAptaParaCadastro : Validator<Transferencia>
    {
        public TransferenciaAptaParaCadastro()
        {
            var transferenciaVazia = new TransferenciaDevePossuirLotesSpecification();

            base.Add("transferenciaVazia", new Rule<Transferencia>(transferenciaVazia, "A transferência que " +
                "está tentando realizar não possui nenhum lote, favor informe os lotes."));
        }
    }
}
