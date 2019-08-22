namespace GrupoAOX.Estagio.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GrupoAOX.Estagio.Data.Contexto.ContextoEstagio>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GrupoAOX.Estagio.Data.Contexto.ContextoEstagio context)
        {
            //List<Status> status = new List<Status>();
            //status.Add(new Status() { StatusId = 0, Descricao = "Aguardando integração" });
            //status.Add(new Status() { StatusId = 1, Descricao = "Integrado" });
            //status.Add(new Status() { StatusId = 3, Descricao = "Transferido" });
            //status.Add(new Status() { StatusId = 4, Descricao = "Aguardando faturamento" });
            //status.Add(new Status() { StatusId = 5, Descricao = "Faturado" });
            //status.Add(new Status() { StatusId = 8, Descricao = "Falha na integração" });
            //status.Add(new Status() { StatusId = 9, Descricao = "Descartada" });
            //status.Add(new Status() { StatusId = 99, Descricao = "Bobina antiga" });

            //List<Categoria> categorias = new List<Categoria>();
            //categorias.Add(new Categoria()
            //{
            //    Descricao = "Romaneio",
            //    TipoCategoria = GrupoAox.Estagio.Domain.Enums.TipoCategoria.Romaneio
            //});
            //categorias.Add(new Categoria()
            //{
            //    Descricao = "Ordem de Expedição",
            //    TipoCategoria = GrupoAox.Estagio.Domain.Enums.TipoCategoria.OrdemExpedicao
            //});

            //context.Status.AddRange(status);
            //context.Categorias.AddRange(categorias);

            //context.SaveChanges();
        }
    }
}
