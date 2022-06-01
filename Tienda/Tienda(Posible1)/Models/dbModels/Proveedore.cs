using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tienda_Posible1_.Models.dbModels
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Productos = new HashSet<Producto>();
        }

        [Key]
        [Column("ProveID")]
        public int ProveId { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Horario { get; set; }
        public int Categorias { get; set; }

        [ForeignKey(nameof(Categorias))]
        [InverseProperty(nameof(Categoria.Proveedores))]
        public virtual Categoria CategoriasNavigation { get; set; }
        [InverseProperty(nameof(Producto.ProveedorNavigation))]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
