using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CarritoNegocio
    {
        private const string SESSION_KEY = "Carrito";

        private Carrito carrito;
        
        public CarritoNegocio()
        {
            
            //carrito = new Carrito();
            // Recuperar el carrito desde la sesión, o crear uno nuevo si no existe
            carrito = (Carrito)System.Web.HttpContext.Current.Session[SESSION_KEY] ?? new Carrito();
        }
        private void GuardarCarrito()//  se guardan los cambios en la sesión para evitar perder los cambios al agregar un articulo al carrito
        {
            // Guardar el carrito en la sesión
            System.Web.HttpContext.Current.Session[SESSION_KEY] = carrito;
        }

        public void AgregarAlCarrito(Articulo articulo, int cantidad)
        {
            carrito.AgregarArticulo(articulo, cantidad);
            GuardarCarrito();
        }

        public void EliminarDelCarrito(int idArticulo)
        {
            carrito.EliminarArticulo(idArticulo);
            GuardarCarrito();
        }

        public decimal ObtenerTotal()
        {
            return carrito.CalcularTotal();
        }

        public List<ArticuloEnCarrito> ObtenerAticulos()
        {
            return carrito.Articulos;
        }

        public void VaciarCarrito()
        {
            carrito.VaciarCarrito();
            GuardarCarrito();
        }
    }
}
