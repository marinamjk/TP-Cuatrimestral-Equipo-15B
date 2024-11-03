using Negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class DatosContacto : System.Web.UI.Page
    {
        private CarritoNegocio carritoNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            carritoNegocio = new CarritoNegocio();

            if (!IsPostBack)
            {
                //// Inicializa los valores si es la primera carga
                //DatosDestinatario.Visible = false;
                //DatosFacturacion.Visible = false;
                CargarResumenCompra();
            }
        }

        private void CargarResumenCompra()
        {
            var articulosCarrito = carritoNegocio.ObtenerAticulos();
            decimal calculoTotal = carritoNegocio.ObtenerTotal();

            if (articulosCarrito != null && articulosCarrito.Any())
            {

                lblTotal.Text = $"${calculoTotal:N2}";
                rptResumenCarrito.DataSource = articulosCarrito;
                rptResumenCarrito.DataBind();
            }
            else
            {
                lblTotal.Text = "$0.00";
            }
        }

        protected void btnMediosDePago_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CheckOut.aspx");
        }

        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEnvio.Checked)
            {
                DatosDestinatario.Visible = true;
                DatosFacturacion.Visible = false;
            }
            else if (rbRetiro.Checked)
            {
                DatosFacturacion.Visible = true;
                DatosDestinatario.Visible = false;
            }
        }
    }
}