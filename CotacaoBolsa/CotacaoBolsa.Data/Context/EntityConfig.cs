using CotacaoBolsa.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CotacaoBolsa.Data.Context
{
    public class EntityConfig
    {
        private ModelBuilder _modelBuilder;
        public EntityConfig(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Configure()
        {
            foreach (var pb in _modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?))
                .Select(p => _modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name)))
            {
                pb.HasColumnType("datetime");
            }

            _modelBuilder.Entity<Cotacao>(e => {
                e.HasIndex(c => c.DataCotacao);
                e.Property(c => c.ValorFechamento).HasColumnType("decimal(18,4)");
            });
        }
    }
}
