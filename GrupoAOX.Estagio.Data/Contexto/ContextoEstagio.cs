﻿using GrupoAox.Estagio.Domain.Entidades;
using GrupoAOX.Estagio.Data.ConfigEntidades;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace GrupoAOX.Estagio.Data.Contexto
{
    public class ContextoEstagio : DbContext
    {
        public ContextoEstagio() : base("Pw1ProFsa")
        {

        }

        public DbSet<int_exp_Etiqueta_Producao> Lotes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<LogLotes> LogLotes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lembrete> Lembretes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new int_exp_Etiqueta_ProducaoConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new TransferenciaConfig());
            modelBuilder.Configurations.Add(new StatusConfig());
            modelBuilder.Configurations.Add(new PermissaoConfig());
            modelBuilder.Configurations.Add(new LogLotesConfig());
            modelBuilder.Configurations.Add(new CategoriaConfig());
            modelBuilder.Configurations.Add(new LembreteConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().
                Where(entry => entry.Entity.GetType().GetProperty("DataMovimento") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataMovimento").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataMovimento").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
