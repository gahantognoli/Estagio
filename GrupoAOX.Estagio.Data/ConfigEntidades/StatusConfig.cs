using GrupoAox.Estagio.Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GrupoAOX.Estagio.Data.ConfigEntidades
{
    public class StatusConfig : EntityTypeConfiguration<Status>
    {
        public StatusConfig()
        {
            Property(s => s.StatusId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            Ignore(s => s.ValidationResult);

            ToTable("Status");
        }
    }
}
