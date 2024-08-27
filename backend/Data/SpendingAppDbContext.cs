using Microsoft.EntityFrameworkCore;
using SPENDINGAPP.backend.Models;

namespace SPENDINGAPP.backend.Data
{
    public class SpendingAppDbContext : DbContext
    {
        public SpendingAppDbContext(DbContextOptions<SpendingAppDbContext> options)
            : base(options)
        {
        }

        // DbSet properties represent collections of your models
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specify precision and scale for the Amount property
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Income>()
                .Property(i => i.Amount)
                .HasColumnType("decimal(18,2)");

            // can add additional config here if needed
        }
    }
}

