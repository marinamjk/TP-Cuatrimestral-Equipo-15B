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
    public partial class ListaPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PedidoNegocio pn = new PedidoNegocio();

                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    repPedidos.DataSource = pn.listarPedidosPorUsuario();
                    repPedidos.DataBind();
                }

            }
        }
    }
}