using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExWebApiAutos.Model.ExWebApiAutos
{
    public partial class ExWebApiDbContext : DbContext
    {
        public ExWebApiDbContext()
        {
        }

        public ExWebApiDbContext(DbContextOptions<ExWebApiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAuto> TAuto { get; set; }
        public virtual DbSet<TMarca> TMarca { get; set; }

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

                entity.Property(e => e.AutoMecanico).IsUnicode(false);

                entity.Property(e => e.AutoNroplaca).IsUnicode(false);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.TAuto)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Auto_T_Marca");
            });

            modelBuilder.Entity<TMarca>(entity =>
            {
                entity.Property(e => e.MarcaId).ValueGeneratedNever();

                entity.Property(e => e.MarcaNombre).IsUnicode(false);
            });
        }
    }
}
