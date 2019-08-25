using DomainValidation.Validation;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Specifications.Permissoes;

namespace GrupoAox.Estagio.Domain.Validations.Permissoes
{
    public class PermissaoAptoParaCadastroValidation : Validator<Permissao>
    {
        public PermissaoAptoParaCadastroValidation(IPermissaoRepositorio permissaoRepositorio)
        {
            var descricaoDuplicada = new PermissaoDevePossuirDescricaoUnicaSpecification(permissaoRepositorio);
            var siglaDuplicada = new PermissaoDevePossuirSiglaUnicaSpecification(permissaoRepositorio);

            base.Add("descricaoDuplicada", new Rule<Permissao>(descricaoDuplicada, "Descrição já cadastrada"));
            base.Add("siglaDuplicada", new Rule<Permissao>(siglaDuplicada, "Sigla já cadastrada"));
        }
    }
}
