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
                    CategoriaNegocio categorias = new CategoriaNegocio();
                    catalogo= negocio.listarConSP().Where(a=>a.Estado==true).ToList();
                    var categoria = categorias.listarCategorias();
                    repArticulos.DataSource = catalogo;
                    repArticulos.DataBind();
                    ddlCategoria.DataSource = categoria;
                    ddlCategoria.DataBind();
                    ddlOrdenamiento.Items.Add("Menor a Mayor");
                    ddlOrdenamiento.Items.Add("Mayor a Menor");
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

        protected void BtAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            CategoriaNegocio categorias = new CategoriaNegocio();
            int IdCategoria = ddlCategoria.SelectedIndex+1;
            var Articulos = negocio.listarFiltrado(IdCategoria);
            var categoria = categorias.listarCategorias();
            repArticulos.DataSource = Articulos;
            repArticulos.DataBind();
            ddlCategoria.DataSource = categoria;
            ddlCategoria.DataBind();
        }

        protected void Bordenar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            catalogo = negocio.listarConSP().Where(a => a.Estado == true).ToList();
            List<Articulo> articulo_ordenado = new List<Articulo>();
            if (ddlOrdenamiento.Text == "Mayor a Menor")
            {
                articulo_ordenado = catalogo.OrderByDescending(a => a.Precio).ToList();
            }
            else
            {
                articulo_ordenado = catalogo.OrderBy(a => a.Precio).ToList();
            }
            repArticulos.DataSource = articulo_ordenado;
            repArticulos.DataBind();
        }
    }
}