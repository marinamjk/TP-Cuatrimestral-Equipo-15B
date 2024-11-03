using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Carrito : System.Web.UI.Page
    {
        private CarritoNegocio carritoNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            InicializarCarritoNegocio();

            if (!IsPostBack)
            {
                carritoNegocio = new CarritoNegocio();
                var articulos = carritoNegocio.ObtenerAticulos();
                if(articulos.Count != 0)
                {
                    CargarCarrito();
                }
                else
                {
                    lblCarritoVacio.Visible = true;
                    gvCarrito.Visible = false;
                    
                }
            }
        }
        private void InicializarCarritoNegocio()
        {
            if (carritoNegocio == null)
            {
                carritoNegocio = new CarritoNegocio();
            }
        }
        //funcion para vista preliminar
        private void CargarCarrito()
        {
            var articulos = carritoNegocio.ObtenerAticulos();

            if (articulos.Count == 0)
            {               
                gvCarrito.Visible = false;
                lblCarritoVacio.Visible = false;
                
                total.Visible = false;
                btn.Visible = false;
                lblTotal.Text = "$0.00";
                return;
            }

            DataTable datosCarrito = new DataTable();
            datosCarrito.Columns.Add("IdArticulo", typeof(int));
            datosCarrito.Columns.Add("Nombre", typeof(string));
            datosCarrito.Columns.Add("Cantidad", typeof(int));
            datosCarrito.Columns.Add("Precio", typeof(decimal));

            foreach (var articuloEnCarrito in articulos)
            {
                datosCarrito.Rows.Add
                (
                        articuloEnCarrito.Articulo.IdArticulo,
                        articuloEnCarrito.Articulo.Nombre,
                        articuloEnCarrito.Cantidad,
                        articuloEnCarrito.Subtotal.ToString("N2")
                );

            }

            gvCarrito.DataSource = datosCarrito;
            gvCarrito.DataBind();

            gvCarrito.Visible = true;
            lblCarritoVacio.Visible = false;
            
            total.Visible = true;
            btn.Visible = true;

            //Calculo del total
            decimal calculoTotal = carritoNegocio.ObtenerTotal();
            lblTotal.Text = $"${calculoTotal:N2}";

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            InicializarCarritoNegocio();

            Button btn = (Button)sender;
            int idArticulo = int.Parse(btn.CommandArgument);
            carritoNegocio.EliminarDelCarrito(idArticulo);
            CargarCarrito();
        }




        protected void btnCalcularEnvio_Click(object sender, EventArgs e)
        {

        }

        protected void btnVerDetalles_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idArticulo = int.Parse(btn.CommandArgument);
            Response.Redirect($"~/Detalle.aspx?id={idArticulo}");
        }
        protected void btnIniciarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DatosContacto.aspx");
        }
    }
}