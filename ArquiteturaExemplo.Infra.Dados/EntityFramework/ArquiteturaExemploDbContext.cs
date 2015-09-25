using ArquiteturaExemplo.Dominio.Entidades;
using ArquiteturaExemplo.Dominio.Entidades.Interfaces;
using ArquiteturaExemplo.Infra.Dados.EntityFramework.Configuracoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Infra.Dados.EntityFramework
{
    public class ArquiteturaExemploDbContext : DbContext
    {
        public ArquiteturaExemploDbContext()
            : base("ArquiteturaExemploDb") 
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }
        //public DbSet<ItemPedido> ItensPedido { get; set; }


        /// <summary>
        /// Configura por meio do Fluent API como as entidades serão persistidas
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Convenções
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new ItemPedidoConfiguration());
        }

        /// <summary>
        /// Força a chamada da validação padrão para todas as entidades que implementam a interface IValidaEntidade
        /// </summary>
        /// <param name="entityEntry"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry.Entity is IValidaEntidade)
            {
                IValidaEntidade entidade = (IValidaEntidade)entityEntry.Entity;
                entidade.ValidarEntidade();
            }
            return base.ValidateEntity(entityEntry, items);
        }

        /// <summary>
        /// Ajusta as datas de Cadastro e Alteração antes de salvar
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified))
            {
                var agora = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = agora;
                    entry.Property("DataAlteracao").CurrentValue = agora;
                }

                if (entry.State == EntityState.Modified)
                {
                    // preserva data de cadastro, mesmo que alguém a altere
                    entry.Property("DataCadastro").CurrentValue = entry.Property("DataCadastro").OriginalValue;
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAlteracao").CurrentValue = agora;
                }
            }

            return base.SaveChanges();
        }

    }
}
