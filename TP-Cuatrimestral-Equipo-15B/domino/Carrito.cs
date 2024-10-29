using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrito
    {
        public List<ArticuloEnCarrito> Articulos { get; set; } = new List<ArticuloEnCarrito>();
        public void AgregarArticulo(Articulo articulo, int cantidad)
        {
            var articuloEnCarrito = Articulos.FirstOrDefault(a => a.Articulo.IdArticulo == articulo.IdArticulo);

            if (articuloEnCarrito != null)
            {
                //si existe el artiuculo aumenta la cantidad
                articuloEnCarrito.Cantidad += cantidad;
            }
            else
            {
                Articulos.Add(new ArticuloEnCarrito { Articulo = articulo, Cantidad = cantidad });
            }
        }

        public void EliminarArticulo(int idArticulo)
        {
            Articulos.RemoveAll(a => a.Articulo.IdArticulo == idArticulo);
        }

        public decimal CalcularTotal()
        {
            return Articulos.Sum(a => a.Articulo.Precio * a.Cantidad);
        }

        public void VaciarCarrito()
        {
            Articulos.Clear();
        }
    }
}
