using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ArticuloEnCarrito
    {
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Articulo.Precio * Cantidad;
    }
}
