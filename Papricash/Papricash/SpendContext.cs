using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Papricash
{
    public class SpendContext : DbContext
    {
        private DbSet<Spending> Spendings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=Spendings.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Make amount required
            modelBuilder.Entity<Spending>()
                .Property(s => s.amount)
                .IsRequired();
        }
    }
}