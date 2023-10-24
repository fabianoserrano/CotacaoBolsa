using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CotacaoBolsa.Data.Entities;

namespace CotacaoBolsa.Data.Context
{
    public class CotacaoBolsaContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CotacaoBolsaContext(IConfiguration configuration)
        {
            _configuration = configuration;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new EntityConfig(modelBuilder).Configure();
        }

        public override int SaveChanges()
        {
            SetDefaultValues();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetDefaultValues();
            return await base.SaveChangesAsync();
        }

        private void SetDefaultValues()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataModificacao") != null))
            {
                if ((entry.State == EntityState.Added) || (entry.State == EntityState.Modified))
                    entry.Property("DataModificacao").CurrentValue = DateTime.Now;
            }
        }

        public DbSet<Cotacao> Cotacao { get; set; }

    }
}
