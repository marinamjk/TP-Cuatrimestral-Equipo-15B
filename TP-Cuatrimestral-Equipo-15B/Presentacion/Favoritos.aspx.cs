using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cargarRepeter();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void cargarRepeter()
        {
            AgregadosNegocio ag = new AgregadosNegocio();
            if (Session["usuario"] != null)
            {
                repFavoritos.DataSource = ag.listarFavoritos(int.Parse(Session["usuario"].ToString()));
                repFavoritos.DataBind();
            }
        }

        protected void repFavoritos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}