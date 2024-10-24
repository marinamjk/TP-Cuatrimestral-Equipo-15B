using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class AdministrarPedido : System.Web.UI.Page
    {
        ArticuloNegocio artNegocio = new ArticuloNegocio();
        public bool ConfirmaCancelacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            gvItemsComprados.DataSource = artNegocio.listar();
            gvItemsComprados.DataBind();

            ConfirmaCancelacion = false;
            if (!IsPostBack)
            {
                List<ListItem> items = new List<ListItem>
                {
                    new ListItem("Pedido Recibido", "1"),
                    new ListItem("Pago recibido", "2"),
                    new ListItem("Pedido en preparación", "3"),
                    new ListItem("Listo para Retirar", "4"),
                    new ListItem("Pedido retirado", "5"),
                    //si el pedido es enviado se agregarán los siguientes items en lugar de los dos anteriores
                    new ListItem("Pedido enviado", "6"),
                    new ListItem("Pedido entregado", "7"),

                };

                cblEstadoPedido.DataSource = items;
                cblEstadoPedido.DataTextField = "Text";
                cblEstadoPedido.DataValueField = "Value";
                cblEstadoPedido.DataBind();

                cblEstadoPedido.Items[0].Enabled = true;

                // Deshabilitar los demás CheckBoxes
                for (int i = 1; i < cblEstadoPedido.Items.Count; i++)
                {
                    cblEstadoPedido.Items[i].Enabled = false;
                }
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
                    //cambiar el estado del pedido a cancelado
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
