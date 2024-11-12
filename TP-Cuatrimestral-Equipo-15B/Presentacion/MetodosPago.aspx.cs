using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class MetodosPago : System.Web.UI.Page
    {
        private CarritoNegocio carritoNegocio;
        private PedidoNegocio pedidoNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            carritoNegocio = new CarritoNegocio();
            pedidoNegocio = new PedidoNegocio();
            if (!IsPostBack)
            {
                CargarResumenCompra();
            }
        }
        private void CargarResumenCompra()
        {
            var articulosCarritos = carritoNegocio.ObtenerAticulos();
            decimal calculoTotal = carritoNegocio.ObtenerTotal();

            if (articulosCarritos != null && articulosCarritos.Any())
            {
                lblTotal.Text = $"${calculoTotal:N2}";
                rptResumenCarrito.DataSource= articulosCarritos;
                rptResumenCarrito.DataBind();
            }
        }
        protected void btnPagoEfectivo_Click(object sender, EventArgs e)
        {           
            Session["MetodoPago"] = 1; // 1 sería el ID del pago en efectivo.
        }

        protected void btnPagoMercadoPago_Click(object sender, EventArgs e)
        {            
            Session["MetodoPago"] = 2; // 2 sería el ID de MercadoPago.
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
           
            var metodoPagoSeleccionado = Session["MetodoPago"];

            if (metodoPagoSeleccionado == null)
            {
                lblError.Text = "Por favor, seleccione un método de pago antes de continuar.";
                lblError.Visible = true;  

                return;
            }

            // Verificar si se seleccionó envío o retiro
            string tipoEntrega = (string)Session["TipoEntrega"];

            if (tipoEntrega == "Envio")
            {
                if (Session["NombreCliente"] == null || Session["ApellidoCliente"] == null ||
                    Session["Email"] == null || Session["Telefono"] == null ||
                    Session["Calle"] == null || Session["Numero"] == null ||
                    Session["CodigoPostal"] == null || Session["Provincia"] == null || Session["DNI"] == null)
                {
                    lblError.Text = "Por favor, complete todos los datos de contacto y dirección para el envío.";
                    lblError.Visible = true;
                    return;
                }
            }
            else if (tipoEntrega == "Retiro")
            {
                if (Session["NombreCliente"] == null || Session["ApellidoCliente"] == null ||
                    Session["Email"] == null || Session["Telefono"] == null ||
                    Session["DNI"] == null)
                {
                    lblError.Text = "Por favor, complete los datos de facturación y la persona que retirará el pedido.";
                    lblError.Visible = true;
                    return;
                }
            }
            else
            {
                lblError.Text = "Por favor, seleccione un método de entrega válido.";
                lblError.Visible = true;
                return;
            }

            // Crear objeto Pedido con los datos del cliente
            var pedido = new Pedido
            {
                NombreCliente = (string)Session["NombreCliente"],
                ApellidoCliente = (string)Session["ApellidoCliente"],
                Email = (string)Session["Email"],
                Telefono = (string)Session["Telefono"],
                Calle = tipoEntrega == "Envio" ? (string)Session["Calle"] : null,
                Numero = tipoEntrega == "Envio" ? (string)Session["Numero"] : null,
                CodigoPostal = tipoEntrega == "Envio" ? (string)Session["CodigoPostal"] : null,
                Provincia = tipoEntrega == "Envio" ? (string)Session["Provincia"] : null, 
                DNI = (string)Session["DNI"],
                IdMetodoPago = (int)metodoPagoSeleccionado,
                Total = carritoNegocio.ObtenerTotal(),
                TipoEntrega = (string)Session["TipoEntrega"]
            };

            List<ArticuloEnCarrito> articulos = carritoNegocio.ObtenerAticulos();
            int idNuevoPedido = pedidoNegocio.GuardarPedido(pedido);
                                    
            pedidoNegocio.GuardarDetallesPedido(idNuevoPedido,articulos);
            Response.Redirect("~/ConfirmacionCompra.aspx");
        }


    }//fin metodos pago
}//fin presentacion