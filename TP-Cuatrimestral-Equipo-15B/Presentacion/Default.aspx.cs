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
            try
            {               
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
            
                    catalogo= negocio.listarConSP().Where(a=>a.Estado==true).ToList();  
                    
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
        protected void repArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Articulo articulo = (Articulo)e.Item.DataItem;
            ImagenNegocio imgNegocio= new ImagenNegocio();
            List<Imagen> images = imgNegocio.buscarImagenesXArticulo(articulo.IdArticulo);
            
            Image imgArticulo = (Image)e.Item.FindControl("imgArticulo");
            if (images != null && images.Count > 0)
            {
                imgArticulo.ImageUrl = images[0].UrlImagen; // Asignar la URL de la primera imagen
            }
            else
            {
                imgArticulo.ImageUrl = "https://media.istockphoto.com/id/1409329028/vector/no-picture-available-placeholder-thumbnail-icon-illustration-design.jpg?s=612x612&w=0&k=20&c=_zOuJu755g2eEUioiOUdz_mHKJQJn-tDgIAhQzyeKUQ="; // Ruta a una imagen predeterminada
            }
            
        }
    }
}