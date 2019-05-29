using DomainValidation.Interfaces.Specification;
using GrupoAox.Estagio.Domain.Entidades;
using System.Text.RegularExpressions;

namespace GrupoAox.Estagio.Domain.Specifications.Usuarios
{
    public class UsuarioDevePossuirEmailValidoSpecification : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return Validar(usuario.Email);
        }

        public bool Validar(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rg.IsMatch(email);
        }
    }
}
