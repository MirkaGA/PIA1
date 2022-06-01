using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda_Posible1_.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {

        public ApplicationUser()
        {
            Pedidos = new HashSet<Pedido>();
        }
        public string Nombre { get; set; }

        [InverseProperty(nameof(Pedido.ClienteNavegation))]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
