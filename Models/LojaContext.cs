using Microsoft.EntityFrameworkCore;

namespace ApiEF.Models {
    public class LojaContext : DbContext {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options) {}

        public DbSet<Limpeza> TabelaLimpeza { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Limpeza>(e =>
            {
                e
                .ToTable("Limpeza")
                .HasKey(k => k.Id);

                e
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            });
        }
    }
}