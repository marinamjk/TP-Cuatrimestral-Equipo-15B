using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domino
{
    public class Carrito
    {
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
        public void AgregarAticulo(Articulo articulo)
        {
            Articulos.Add(articulo);
        }

        public void EliminarArticulo(int idArticulo)
        {
            Articulos.RemoveAll(a=>a.IdArticulo == idArticulo);
        }

        public decimal CalcularTotal()
        {
            return Articulos.Sum(a=> a.Precio);
        }

        public void VaciarCarrito()
        {
            Articulos.Clear();
        }
    }
}
