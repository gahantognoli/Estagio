using GrupoAox.Estagio.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GrupoAOX.Estagio.Data.ConfigEntidades
{
    public class TransferenciaConfig : EntityTypeConfiguration<Transferencia>
    {
        public TransferenciaConfig()
        {
            HasKey(t => t.TransferenciaId);

            Property(t => t.DataMovimento)
                .IsRequired();

            Property(t => t.ArmazemOrigem)
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength();

            Property(t => t.ArmazemDestino)
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength();

            Property(t => t.NumeroDocumento)
                .IsRequired()
                .HasMaxLength(50);

            HasRequired(t => t.Usuario)
                .WithMany(t => t.Transferencias)
                .HasForeignKey(t => t.UsuarioId);

            HasRequired(t => t.Categoria)
                .WithMany(t => t.Transferencias)
                .HasForeignKey(t => t.CategoriaId);

            HasMany(t => t.Lotes)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("TransferenciaId");
                    m.MapRightKey("ApontamentoProducaoId");
                    m.ToTable("TransferenciasLotes");
                });

            Ignore(c => c.ValidationResult);

            ToTable("Transferencias");
        }
    }
}
