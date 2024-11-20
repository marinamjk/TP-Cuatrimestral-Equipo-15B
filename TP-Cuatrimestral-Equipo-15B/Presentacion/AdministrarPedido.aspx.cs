using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Presentacion
{
    public partial class AdministrarPedido : System.Web.UI.Page
    {
       
        public bool ConfirmaCancelacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarListaDeEstado();

                string idPedido = Request.QueryString["id"];

                Pedido pedActual;
                PedidoNegocio pn = new PedidoNegocio();

                Usuario usuario = new Usuario();
                UsuarioManager um = new UsuarioManager();

                if (idPedido != null)
                {
                    gvItemsComprados.DataSource = pn.listarDetallePorPedido(int.Parse(idPedido));
                    gvItemsComprados.DataBind();
                }
                if (!string.IsNullOrEmpty(idPedido))
                {
                    int id = int.Parse(idPedido);
                    pedActual = pn.buscarPedidoPorID(id);
                   

                    int idUser= pedActual.IdUsuario;
                    usuario = um.listarUsuarios().FirstOrDefault(u => u.IdUsuario == idUser);

                    lblIDPedido.Text = "ID del Pedido: " + pedActual.IdPedido.ToString();
                    lblFecha.Text= "Fecha del Pedido: " + pedActual.FechaPedido.ToString("d");
                    lblTotalCompra.Text = "Total: $" + pedActual.Total;
                    lblNombre.Text = "Nombre y Apellido: "+ usuario.Nombre +  ", "+ usuario.Apellido;
                    lblTelefono.Text = "Teléfono: "+usuario.telefono;
                    lblDireccion.Text= usuario.Direccion.Calle + " "+ usuario.Direccion.Numero.ToString() + " CP: " +usuario.Direccion.Localidad.CodigoPostal.ToString() + " Pcia: " + usuario.Direccion.Provincia.Nombre.ToString();

                }

                ConfirmaCancelacion = false;
                
            }

        }

        protected void cargarListaDeEstado()
        {
            string idPedido = Request.QueryString["id"];
            Pedido pedActual= new Pedido();
            if (idPedido != null)
            {
                int id = int.Parse(idPedido);
                PedidoNegocio pn = new PedidoNegocio();
                pedActual = pn.buscarPedidoPorID(id);
                
            }

            List<ListItem> items = new List<ListItem>
            {                
                new ListItem("Pedido recibido", "1"),
                new ListItem("Pago recibido", "2"),
                new ListItem("Pedido en preparación", "3"),
            };

            if (pedActual.TipoEntrega == "Envio")
            {
                items.Add(new ListItem("Pedido enviado", "4"));
                items.Add(new ListItem("Pedido entregado", "5"));
            }
            else
            {
                items.Add(new ListItem("Listo para Retirar", "4"));
                items.Add(new ListItem("Pedido retirado", "5"));
            }

            cblEstadoPedido.DataSource = items;
            cblEstadoPedido.DataTextField = "Text";
            cblEstadoPedido.DataValueField = "Value";
            cblEstadoPedido.DataBind();
            
            for(int i=0; i<pedActual.EstadoPedido; i++)
            {
                cblEstadoPedido.Items[i].Selected = true; // Para seleccionarlo
                cblEstadoPedido.Items[i].Attributes["checked"] = "checked"; // Para marcarlo como "checked"
                cblEstadoPedido.Items[i].Enabled = false;
            }
           
            // Deshabilitar los demás CheckBoxes
            for (int i = pedActual.EstadoPedido+1; i < cblEstadoPedido.Items.Count; i++)
            {
                cblEstadoPedido.Items[i].Enabled = false;
            }
        }
        protected void cblEstadoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < cblEstadoPedido.Items.Count; i++)
            {
                if (cblEstadoPedido.Items[i].Selected)
                {

                    cblEstadoPedido.Items[i].Enabled = false;
                    if (i + 1 < cblEstadoPedido.Items.Count)
                    {
                        cblEstadoPedido.Items[i + 1].Enabled = true;
                    }
                }
                else
                {
                    for (int j = i + 1; j < cblEstadoPedido.Items.Count; j++)
                    {
                        cblEstadoPedido.Items[j].Enabled = false;
                    }
                    break;
                }
            }

            string idPedido = Request.QueryString["id"];
            Pedido pedActual = new Pedido();
            PedidoNegocio pn = new PedidoNegocio();

            if (idPedido != null)
            {
                int id = int.Parse(idPedido);                
                pedActual = pn.buscarPedidoPorID(id);
                pn.cambiarEstadoPedido(pedActual);

            }
        }

        protected void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            ConfirmaCancelacion = true;
        }

        protected void btnConfirmanCancelacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarCancelacion.Checked)
                {
                    string idPedido = Request.QueryString["id"];
                    Pedido pedActual = new Pedido();
                    PedidoNegocio pn = new PedidoNegocio();

                    if (idPedido != null)
                    {
                        int id = int.Parse(idPedido);
                        pedActual = pn.buscarPedidoPorID(id);  
                    }

                    if (pedActual.EstadoPedido < 5)
                    {
                        pn.CancelarPedido(pedActual.IdPedido);
                        Response.Redirect("ListaPedidos.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", "El pedido no se puede cancelar porque ya ha sido entregado");
                        Response.Redirect("Error.aspx", false);
                    }
                    
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}
