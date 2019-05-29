using DomainValidation.Validation;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Specifications.Usuarios;

namespace GrupoAox.Estagio.Domain.Validations.Usuarios
{
    public class UsuarioAptoParaCadastroValidation : Validator<Usuario>
    {
        public UsuarioAptoParaCadastroValidation(IUsuarioRepositorio usuarioRepositorio)
        {
            var emailDuplicado = new UsuarioDevePossuirEmailUnicoSpecification(usuarioRepositorio);
            var loginDuplicado = new UsuarioDevePossuirLoginUnicoSpecification(usuarioRepositorio);
            var emailInvalido = new UsuarioDevePossuirEmailValidoSpecification();

            base.Add("emailDuplicado", new Rule<Usuario>(emailDuplicado, "Email já foi cadastrado!"));
            base.Add("loginDuplicado", new Rule<Usuario>(loginDuplicado, "Login já foi cadastrado!"));
            base.Add("emailInvalido", new Rule<Usuario>(emailInvalido, "Email inválido!"));
        }
    }
}
