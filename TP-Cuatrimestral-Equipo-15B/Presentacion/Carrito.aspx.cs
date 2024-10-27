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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        //funcion para vista preliminar
        private void CargarCarrito()
        {
            DataTable datosPrueba = new DataTable();
            datosPrueba.Columns.Add("ID");
            datosPrueba.Columns.Add("NombreArticulo");
            datosPrueba.Columns.Add("Cantidad");
            datosPrueba.Columns.Add("Precio", typeof(decimal));

            datosPrueba.Rows.Add(1, "Teclado", 2, 200000.00m);
            datosPrueba.Rows.Add(2, "Mouse", 1, 30000.00m);

            gvCarrito.DataSource = datosPrueba;
            gvCarrito.DataBind();

            bool carritoVacio = datosPrueba.Rows.Count == 0;
            gvCarrito.Visible = !carritoVacio;
            lblCarritoVacio.Visible = carritoVacio;
            envio.Visible = !carritoVacio;
            total.Visible = !carritoVacio;
            btn.Visible = !carritoVacio;

            try
            {
                decimal total = 0m;
                foreach (var row in datosPrueba.AsEnumerable())
                {
                    int cantidad = row.Field<int>("Cantidad");
                    decimal precio = row.Field<decimal>("Precio");
                    decimal subtotal = cantidad * precio;
                    total += subtotal;

                    // Imprimir para depuración
                    Console.WriteLine($"Producto: {row.Field<string>("NombreArticulo")} | Cantidad: {cantidad} | Precio: {precio} | Subtotal: {subtotal}");
                }

                lblTotal.Text = $"${total:N2}";
            }
            catch (Exception ex)
            {
                lblTotal.Text = "Error al calcular el total.";
                Console.WriteLine($"Error: {ex.Message} | StackTrace: {ex.StackTrace}");
            }
        }



        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

      

        protected void btnIniciarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DetallesCompra.aspx");
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
    }
}