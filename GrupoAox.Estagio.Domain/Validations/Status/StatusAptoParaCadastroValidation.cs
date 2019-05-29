using DomainValidation.Validation;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Specifications.Status;

namespace GrupoAox.Estagio.Domain.Validations.Status
{
    public class StatusAptoParaCadastroValidation : Validator<GrupoAox.Estagio.Domain.Entidades.Status>
    {
        public StatusAptoParaCadastroValidation(IStatusRepositorio statusRepositorio)
        {
            var statusIdDuplicado = new StatusDevePossuirIdUnicoSpecification(statusRepositorio);

            base.Add("statusIdDuplicado", new Rule<GrupoAox.Estagio.Domain.Entidades.Status>(statusIdDuplicado,
                "O Id já foi cadastrado!"));
        }
    }
}
