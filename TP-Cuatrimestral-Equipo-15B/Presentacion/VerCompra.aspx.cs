using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;

namespace Presentacion
{
    public partial class VerCompra : System.Web.UI.Page
    {
        public bool ConfirmarCancelacion { get; set; }

        public string descripcionEstado;

        public int valorEstado;

        public Pedido pedido;

        public bool calificado;
        public bool calificar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {       
                PedidoNegocio pn = new PedidoNegocio();
                string idPedido = Request.QueryString["id"];
                Pedido pedActual;
                Usuario usuario = new Usuario();
                Session.Add("calificar", false);
                Session.Add("calificado", false);
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    usuario = (Usuario)Session["usuario"];
                }

                if (!string.IsNullOrEmpty(idPedido))
                {
                    int id = int.Parse(idPedido);
                    pedido = pn.listarPedidosPorUsuario(usuario.IdUsuario).FirstOrDefault(p => p.IdPedido == id);

                    Session.Add("Pedido", pedido);

                    pedActual = (Pedido)Session["Pedido"];
                 
                    valorEstado = pedActual.EstadoPedido;
                                      

                    lblFecha.Text = "Fecha de pedido: " + pedActual.FechaPedido.ToString("dd MMMM yyyy");
                    lblTotalCompra.Text = "Total: " + pedActual.Total.ToString("F2");

                    gvItemsComprados.DataSource = pn.listarDetallePorPedido(id);
                    gvItemsComprados.DataBind();

                }
                ConfirmarCancelacion = false;          

            }
            cargarDescripcionEstado();

            if (Session["calificado"] != null)
            {
                calificado = (bool)Session["calificado"];
            }
            if (Session["calificar"] != null)
            {
                calificar = (bool)Session["calificar"];
            }
        }

        public void cargarDescripcionEstado()
        {
           
            Pedido pedActual = (Pedido)Session["Pedido"];
            if (pedActual != null)
            {
                valorEstado = pedActual.EstadoPedido;
            }    
            switch (valorEstado)
            {
                case 1:
                    descripcionEstado = "Pedido Realizado";
                    break;
                case 2:
                    descripcionEstado = "Pago Recibido";
                    break;
                case 3:
                    descripcionEstado = "Pedido En Preparación";
                    break;
                case 4:
                    if (pedActual.TipoEntrega == "Envio")
                    {
                        descripcionEstado = "En camino";
                    }
                    else
                    {
                        descripcionEstado = "Listo para Retirar";
                    }
                    break;
                case 5:
                    if (pedActual.TipoEntrega == "Envio")
                    {
                        descripcionEstado = "Pedido Entregado";
                    }
                    else
                    {
                        descripcionEstado = "¨Pedido Retirado";
                    }
                    break;
                case 6:
                    descripcionEstado = "Pedido Cancelado";
                    break;
            }
        }
        protected void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            ConfirmarCancelacion = true;

        }

        protected void btnConfirmanCancelacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarCancelacion.Checked)
                {
                    PedidoNegocio pn = new PedidoNegocio();
                    Pedido pedAct = (Pedido)Session["Pedido"];
                    if (pedAct.EstadoPedido < 5) {
                        pn.CancelarPedido(pedAct.IdPedido);
                        Response.Redirect("Historial.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", "El pedido no se puede cancelar porque ya ha sido entregado. Consulte devolución");
                        Response.Redirect("Error.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void gvItemsComprados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Calificar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idArt = Convert.ToInt32(gvItemsComprados.DataKeys[index].Value);
                Session.Add("idArt", idArt);

                Pedido pedActual = (Pedido)Session["Pedido"];

                AgregadosNegocio an = new AgregadosNegocio();
                Session["calificado"] = an.BuscarPuntaje(pedActual.IdPedido, idArt) > 0 ? true: false;
                calificado = (bool)Session["calificado"];
                if (pedActual.EstadoPedido == 5)
                {
                    Session["calificar"] = true;
                    calificar = (bool)Session["calificar"];
                } else
                {
                    calificar = false;
                    lblCalificar.Text = "No se puede calificar aún porque no ha sido entregado";
                }           
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                AgregadosNegocio ag = new AgregadosNegocio();
                int idArt = int.Parse(Session["idArt"].ToString());
                int puntaje = int.Parse(txtCalificacion.Text);
                string idPedido = Request.QueryString["id"];
                calificado = (bool)Session["calificado"];
                if (calificado == false)
                {
                    ag.agregarPuntaje(int.Parse(idPedido), idArt, puntaje);
                    
                    Session["calificado"] = true;   
                }            

            }
            catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
    
        }
    }
}