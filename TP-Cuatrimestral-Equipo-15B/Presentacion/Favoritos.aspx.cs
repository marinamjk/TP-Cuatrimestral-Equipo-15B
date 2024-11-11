using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
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
            try
            {
                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    repFavoritos.DataSource = ag.listarFavoritos(usuario.IdUsuario);
                    repFavoritos.DataBind();
                }
            }catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void repFavoritos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Articulo articulo = (Articulo)e.Item.DataItem;
            Session.Add("articulo", articulo);
            ImagenNegocio imgNegocio = new ImagenNegocio();
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

        protected void btnAgregarAlCarrito_Command(object sender, CommandEventArgs e)
        {
            try
            {
                ArticuloNegocio an = new ArticuloNegocio();

                if (e.CommandName == "AgregarAlCarrito")
                {
                    int idArt = Convert.ToInt32(e.CommandArgument);
                    
                    Articulo articulo= an.buscarArticuloXId(idArt);
                                 
                    if (1 <= articulo.Stock)
                    {
                        CarritoNegocio carritoNegocio = new CarritoNegocio();
                        carritoNegocio.AgregarAlCarrito(articulo, 1);
                        lblConfirmacion.Text = "Artículo agregado al carrito.";
                    }
                    else
                    {       
                        lblConfirmacion.Text = "No hay stock disponible para este artículo";
                    }
                }
                else
                {
                    
                    lblConfirmacion.Text = "Error al agregar articulo al carrito";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error al cargar al carrito", ex.ToString());
                lblConfirmacion.Text = "Error al cargar al carrito: " + ex.Message;
            }

        }

        protected void btnEliminarDeFavoritos_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Eliminar")
                {
                    AgregadosNegocio an = new AgregadosNegocio();
                    int idArt = Convert.ToInt32(e.CommandArgument);
                    Usuario usuario = (Usuario)Session["usuario"];
                    an.eliminarDeFavoritos(usuario.IdUsuario, idArt);
                    cargarRepeter();
                }
            }catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}