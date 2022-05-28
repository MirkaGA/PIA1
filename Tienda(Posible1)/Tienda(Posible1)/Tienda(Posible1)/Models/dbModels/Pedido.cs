using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tienda_Posible1_.Models.dbModels
{
    public partial class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public int Cliente { get; set; }
        public int Producto { get; set; }
        public int? Total { get; set; }


        [ForeignKey(nameof(Cliente))]
        [InverseProperty(nameof(ApplicationUser.Pedidos))]
        public virtual ApplicationUser ClienteNavegation { get; set; }

        [ForeignKey(nameof(Producto))]
        [InverseProperty("Pedidos")]
        public virtual Producto ProductoNavigation { get; set; }
    }
}
