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
    public partial class Default : System.Web.UI.Page
    {
       public List<Articulo> catalogo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                catalogo = negocio.listarConSP();

                if (!IsPostBack)
                {
                    repArticulos.DataSource = catalogo;
                    repArticulos.DataBind();
                    
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnQuitarFiltroCategorias_Click(object sender, EventArgs e)
        {

        }
    }
}