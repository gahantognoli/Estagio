using GrupoAox.Estagio.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GrupoAOX.Estagio.Data.ConfigEntidades
{
    public class CategoriaConfig : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfig()
        {
            HasKey(c => c.CategoriaId);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            //Property(c => c.TipoCategoria)
            //    .IsRequired();

            Ignore(c => c.ValidationResult);

            ToTable("Categorias");
        }
    }
}
