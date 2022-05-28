using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Tienda_Posible1_.Models.dbModels
{
    public partial class TiendaContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public TiendaContext()
        {
        }

        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }

            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedidos_Producto");

                entity.HasOne(d => d.ClienteNavegation)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Cliente)
                .HasConstraintName("FK_Pedidos_Usuario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Producto");

                entity.HasOne(d => d.ProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Proveedor)
                    .HasConstraintName("FK_Producto_Proveedores");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.Property(e => e.Horario).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.CategoriasNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.Categorias)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedores_Proveedores");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
