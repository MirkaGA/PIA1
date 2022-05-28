using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tienda_Posible1_.Models.dbModels
{
    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        [Key]
        [Column("ProductoID")]
        public int ProductoId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(255)]
        public string Descripcion { get; set; }
        public int? Proveedor { get; set; }
        public int? Stock { get; set; }
        public string Imagen { get; set; }
        public int Categoria { get; set; }

        [ForeignKey(nameof(Categoria))]
        [InverseProperty("Productos")]
        public virtual Categoria CategoriaNavigation { get; set; }
        [ForeignKey(nameof(Proveedor))]
        [InverseProperty(nameof(Proveedore.Productos))]
        public virtual Proveedore ProveedorNavigation { get; set; }
        [InverseProperty(nameof(Pedido.ProductoNavigation))]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
