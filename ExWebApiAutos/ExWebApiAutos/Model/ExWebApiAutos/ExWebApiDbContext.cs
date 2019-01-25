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
                entity.HasKey(e => e.AutoId);

                entity.ToTable("T_Auto");

                entity.Property(e => e.AutoId)
                    .HasColumnName("auto_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AutoAniofabri).HasColumnName("auto_aniofabri");

                entity.Property(e => e.AutoColor)
                    .IsRequired()
                    .HasColumnName("auto_color")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AutoFull)
                    .IsRequired()
                    .HasColumnName("auto_full")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AutoMecanico)
                    .IsRequired()
                    .HasColumnName("auto_mecanico")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AutoNroasientos).HasColumnName("auto_nroasientos");

                entity.Property(e => e.AutoNroplaca)
                    .IsRequired()
                    .HasColumnName("auto_nroplaca")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MarcaId).HasColumnName("marca_id");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.TAuto)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Auto_T_Marca");
            });

            modelBuilder.Entity<TMarca>(entity =>
            {
                entity.HasKey(e => e.MarcaId);

                entity.ToTable("T_Marca");

                entity.Property(e => e.MarcaId)
                    .HasColumnName("marca_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MarcaNombre)
                    .IsRequired()
                    .HasColumnName("marca_nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
