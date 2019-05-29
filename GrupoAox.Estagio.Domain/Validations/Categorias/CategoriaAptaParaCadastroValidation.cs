using DomainValidation.Validation;
using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Specifications.Categorias;

namespace GrupoAox.Estagio.Domain.Validations.Categorias
{
    public class CategoriaAptaParaCadastroValidation : Validator<Categoria>
    {
        public CategoriaAptaParaCadastroValidation(ICategoriaRepositorio categoriaRepositorio)
        {
            var descricaoDuplicada = new CategoriaDevePossuirDescricaoUnicaSpecification(categoriaRepositorio);

            base.Add("descricaoDuplicada", new Rule<Categoria>(descricaoDuplicada, "Descrição já cadastrada!"));
        }
    }
}
