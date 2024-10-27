using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class VerCompra : System.Web.UI.Page
    {
        ArticuloNegocio artNegocio = new ArticuloNegocio();
        public bool ConfirmarCancelacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmarCancelacion = false;
            gvItemsComprados.DataSource = artNegocio.listarConSP();
            gvItemsComprados.DataBind();
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
                    //Eliminar
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