using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tienda_Posible1_.Models.dbModels
{
    public partial class Categoria
    {
        public Categoria()
        {
            Productos = new HashSet<Producto>();
            Proveedores = new HashSet<Proveedore>();
        }

        [Key]
        public int IdCategorias { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty(nameof(Producto.CategoriaNavigation))]
        public virtual ICollection<Producto> Productos { get; set; }
        [InverseProperty(nameof(Proveedore.CategoriasNavigation))]
        public virtual ICollection<Proveedore> Proveedores { get; set; }
    }
}
