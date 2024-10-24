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
            datosPrueba.Columns.Add("Precio");

            
            datosPrueba.Rows.Add(1, "Teclado", 2, "$200.000.00");
            datosPrueba.Rows.Add(2, "Mouse", 1, "$30.000.00");

            // hago que el gridview tome los datos de el datatable
            gvCarrito.DataSource = datosPrueba;
            gvCarrito.DataBind();
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

      

        protected void btnIniciarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DetallesCompra.aspx");
        }
    }
}