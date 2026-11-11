using System.Configuration;
using Microsoft.EntityFrameworkCore;
using SmartBusinessPro.Models;

namespace SmartBusinessPro.Data
{
    /// <summary>
    /// Contexto centralizado de acceso a datos. Toda la aplicación usa esta clase
    /// para conectarse a SQL Server, sin repetir la configuración en cada formulario.
    /// </summary>
    public class SmartBusinessContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string? cadena = ConfigurationManager
                    .ConnectionStrings["SmartBusinessConnection"]?.ConnectionString;

                if (string.IsNullOrWhiteSpace(cadena))
                {
                    throw new InvalidOperationException(
                        "No se encontró la cadena de conexión 'SmartBusinessConnection' en App.config.");
                }

                // Proveedor de SQL Server para Entity Framework Core
                optionsBuilder.UseSqlServer(cadena);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(e =>
            {
                e.ToTable("Categorias");
                e.HasKey(c => c.CategoriaId);
                e.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Producto>(e =>
            {
                e.ToTable("Productos");
                e.HasKey(p => p.ProductoId);
                e.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                e.Property(p => p.Precio).HasColumnType("decimal(10,2)");

                e.HasOne(p => p.Categoria)
                 .WithMany(c => c.Productos)
                 .HasForeignKey(p => p.CategoriaId);
            });
        }
    }
}
