using dominio;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class AltaModArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                CargarImagenes();
            }
        }


        protected void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            string urlImagen = txtUrlImagen.Text;

            revUrlImagen.Validate();
            if (!revUrlImagen.IsValid)
            {
                txtUrlImagen.Text = string.Empty;
                return;
            }


            List<Imagen> images = (List<Imagen>)Session["ImagesList"] ?? new List<Imagen>();
            images.Add(new Imagen { UrlImagen = urlImagen });

            Session["ImagesList"] = images;
            RepeaterImages.DataSource = images;
            RepeaterImages.DataBind();

            txtUrlImagen.Text = string.Empty;
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            Button btnQuitar = (Button)sender;
            int index = Convert.ToInt32(btnQuitar.CommandArgument);

            List<Imagen> images = (List<Imagen>)Session["ImagesList"];

            if (images != null && index >= 0 && index < images.Count)
            {
                images.RemoveAt(index);
                                
                Session["ImagesList"] = images;
                RepeaterImages.DataSource = images;
                RepeaterImages.DataBind();
            }

        }
        private void CargarImagenes()
        {
            
            List<Imagen> images = (List<Imagen>)Session["ImagesList"] ?? new List<Imagen>();

            RepeaterImages.DataSource = images;
            RepeaterImages.DataBind();
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}