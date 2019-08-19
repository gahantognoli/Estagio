using GrupoAox.Estagio.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GrupoAOX.Estagio.Data.ConfigEntidades
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.UsuarioId);

            Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Ativo)
                .IsRequired();

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.CaminhoImg)
                .IsOptional()
                .HasColumnType("varchar(max)");

            HasMany(u => u.Permissoes)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UsuarioId");
                    m.MapRightKey("PermissaoId");
                    m.ToTable("PermissoesUsuarios");
                });

            Ignore(u => u.ValidationResult);

            ToTable("Usuarios");
        }
    }
}
