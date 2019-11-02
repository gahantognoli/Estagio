using GrupoAox.Estagio.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GrupoAOX.Estagio.Data.ConfigEntidades
{
    public class LembreteConfig : EntityTypeConfiguration<Lembrete>
    {
        public LembreteConfig()
        {
            HasKey(c => c.LembreteId);

            Property(c => c.Descricao)
                .HasMaxLength(300)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.Concluido)
                .IsRequired();

            Property(c => c.DataLancamento)
                .IsRequired();

            HasRequired(c => c.Transferencia)
                .WithMany(c => c.Lembretes)
                .HasForeignKey(c => c.TransferenciaId);

            HasRequired(c => c.Usuario)
                .WithMany(c => c.Lembretes)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
