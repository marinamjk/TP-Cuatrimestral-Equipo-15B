using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class AdministrarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView(); 
            }
        }
        private void CargarGridView()
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                dgvMarcas.DataSource = marcaNegocio.listarMarcas();
                dgvMarcas.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
       
        }

        protected void dgvArticulos_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvMarcas.SelectedDataKey.Value.ToString();
        }
    }
}