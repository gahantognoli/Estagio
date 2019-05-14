using GrupoAox.Estagio.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GrupoAOX.Estagio.Data.ConfigEntidades
{
    public class LogLotesConfig : EntityTypeConfiguration<LogLotes>
    {
        public LogLotesConfig()
        {
            HasKey(p => p.LogLoteId);

            Property(l => l.Usuario)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(l => l.Lote)
                .WithMany(l => l.LogLotes)
                .HasForeignKey(l => l.ApontamentoProducaoId);

            ToTable("LogLotes");
        }
    }
}
