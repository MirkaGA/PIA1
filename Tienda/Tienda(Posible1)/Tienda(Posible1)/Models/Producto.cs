using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Tienda_Posible1_.Models

{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }    
        public string Descripcion { get; set; }  
        public string Imagen { get; set; }
        public int Categoria { get; set; }
        public int Proveedor { get; set; }
        public int Stock { get; set; }

        
    }
}
