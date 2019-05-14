using GrupoAox.Estagio.Domain.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GrupoAOX.Estagio.Data.ConfigEntidades
{
    public class int_exp_Etiqueta_ProducaoConfig : EntityTypeConfiguration<int_exp_Etiqueta_Producao>
    {
        public int_exp_Etiqueta_ProducaoConfig()
        {
            HasKey(p => p.ApontamentoProducaoId);

            HasRequired(s => s.Status)
               .WithMany(l => l.Lotes)
               .HasForeignKey(s => s.StatusId);
        }
    }
}
