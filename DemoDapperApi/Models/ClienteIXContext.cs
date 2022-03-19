using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoDapperApi.Models
{
    public partial class ClienteIXContext : DbContext
    {
        public ClienteIXContext()
        {
        }

        public ClienteIXContext(DbContextOptions<ClienteIXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-TCHCACV;Database=ClienteIX;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Carne).HasColumnName("carne");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .HasColumnName("direccion");

                entity.Property(e => e.Dpi).HasColumnName("DPI");

                entity.Property(e => e.Genero)
                    .HasMaxLength(10)
                    .HasColumnName("genero")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombres");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
