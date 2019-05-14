using GrupoAox.Estagio.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GrupoAOX.Estagio.Data.ConfigEntidades
{
    class PermissaoConfig : EntityTypeConfiguration<Permissao>
    {
        public PermissaoConfig()
        {
            HasKey(p => p.PermissaoId);

            Property(p => p.Sigla)
                .IsRequired()
                .HasMaxLength(5);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            ToTable("Permissoes");
        }
    }
}
