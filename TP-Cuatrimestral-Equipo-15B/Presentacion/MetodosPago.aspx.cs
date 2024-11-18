﻿using dominio;
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
        protected bool registrarse;
        protected void Page_Load(object sender, EventArgs e)
        {
            carritoNegocio = new CarritoNegocio();
            pedidoNegocio = new PedidoNegocio();
            if (!IsPostBack)
            {
                CargarResumenCompra();
                registrarse= false;                
                
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
            try
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

                Usuario usuario = (Usuario)Session["usuario"];
                UsuarioManager um = new UsuarioManager();

                usuario.IdUsuario= um.agregarUsuario(usuario);
                usuario.Nombre = (string)Session["NombreCliente"];
                usuario.Apellido = (string)Session["ApellidoCliente"];
                usuario.telefono = (string)Session["Telefono"];
                usuario.Dni = (string)Session["DNI"];

                Direccion direccion = new Direccion(); ;
                if (tipoEntrega == "Envio")
                {
                    direccion.Calle = Session["Calle"].ToString();
                    direccion.Numero = int.Parse(Session["Numero"].ToString());

                    ListItem provinciaSeleccionada = (ListItem)Session["Provincia"];
                    string NombreProvinciaSeleccionada = provinciaSeleccionada.Text;   // Obtiene el texto.
                    byte IdProvinciaSeleccionada = byte.Parse(provinciaSeleccionada.Value); // Obtiene el valor.
                    Provincia p = new Provincia();
                    p.Id = IdProvinciaSeleccionada;
                    direccion.Provincia = p;
                    Localidad l = new Localidad();
                    l.CodigoPostal = int.Parse(Session["CodigoPostal"].ToString());
                    direccion.Localidad = l;
                }

                if (!um.buscarDatosPersonales(usuario))
                {                    
                    um.agregarDatosPersonales(usuario);
                }
                else
                {
                    um.ModificarDatosPersonales(usuario);
                }

                if (!um.buscarDireccion(usuario.IdUsuario) && tipoEntrega == "Envio")
                {                   
                    um.agregarDireccion(direccion, usuario.IdUsuario);
                }
                else if(um.buscarDireccion(usuario.IdUsuario) && tipoEntrega == "Envio")
                {
                    um.ModificarDireccion(usuario);
                }

                // Crear objeto Pedido con los datos del cliente
                var pedido = new Pedido
                {
                    //NombreCliente = (string)Session["NombreCliente"],
                    //ApellidoCliente = (string)Session["ApellidoCliente"],
                    //Email = (string)Session["Email"],
                    //Telefono = (string)Session["Telefono"],
                    //Calle = tipoEntrega == "Envio" ? (string)Session["Calle"] : null,
                    //Numero = tipoEntrega == "Envio" ? (string)Session["Numero"] : null,
                    //CodigoPostal = tipoEntrega == "Envio" ? (string)Session["CodigoPostal"] : null,
                    //Provincia = tipoEntrega == "Envio" ? (string)Session["Provincia"] : null, 
                    //DNI = (string)Session["DNI"],

                    IdMetodoPago = (int)metodoPagoSeleccionado,
                    Total = carritoNegocio.ObtenerTotal(),
                    TipoEntrega = (string)Session["TipoEntrega"]

                };

                List<ArticuloEnCarrito> articulos = carritoNegocio.ObtenerAticulos();
                //int idNuevoPedido = pedidoNegocio.GuardarPedido(pedido);

                int idNuevoPedido = pedidoNegocio.agregarPedido(pedido, usuario.IdUsuario);
                pedidoNegocio.GuardarDetallesPedido(idNuevoPedido, articulos);

                if (registrarse)
                {
                    um.ModificarEstadoUsuario(usuario.IdUsuario, true);
                }

                Response.Redirect("~/ConfirmacionCompra.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void chkRegistrarse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRegistrarse.Checked)
            {
                registrarse = true;
            }
        }
    }//fin metodos pago
}//fin presentacion