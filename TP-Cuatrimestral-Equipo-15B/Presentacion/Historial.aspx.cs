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
    public partial class Historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PedidoNegocio pn = new PedidoNegocio();
                Usuario usuario = (Usuario)Session["usuario"];
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    repHistorial.DataSource = pn.listarPedidosPorUsuario(usuario.IdUsuario);
                    repHistorial.DataBind();
                }
               
            }
        }
    }
}