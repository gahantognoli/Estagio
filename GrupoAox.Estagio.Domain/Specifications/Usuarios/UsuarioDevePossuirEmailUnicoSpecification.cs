using DomainValidation.Interfaces.Specification;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;

namespace GrupoAox.Estagio.Domain.Specifications.Usuarios
{
    public class UsuarioDevePossuirEmailUnicoSpecification : ISpecification<Usuario>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioDevePossuirEmailUnicoSpecification(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public bool IsSatisfiedBy(Usuario usuario)
        {
            return _usuarioRepositorio.ObterPorEmail(usuario.Email) == null;
        }
    }
}
