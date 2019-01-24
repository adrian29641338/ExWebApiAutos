using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExWebApiAutos.Model.ExWebApiAutos
{
    public partial class ExWebApiAutosDbContext : DbContext
    {
        public ExWebApiAutosDbContext()
        {
        }

        public ExWebApiAutosDbContext(DbContextOptions<ExWebApiAutosDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAuto> TAuto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source = LAPTOP-RL3DO4FV; initial catalog = ExamenAutos; Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAuto>(entity =>
            {
                entity.Property(e => e.AutoId).ValueGeneratedNever();

                entity.Property(e => e.AutoColor).IsUnicode(false);

                entity.Property(e => e.AutoFull).IsUnicode(false);

                entity.Property(e => e.AutoMarca).IsUnicode(false);

                entity.Property(e => e.AutoMecanico).IsUnicode(false);

                entity.Property(e => e.AutoNroplaca).IsUnicode(false);
            });
        }
    }
}
