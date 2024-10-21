using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected Articulo articulo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idQuery = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(idQuery))
                {
                    int idArticulo = int.Parse(idQuery);
                    cargarArticulo(idArticulo);

                    if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                    {
                        repeterImagenes.DataSource = articulo.Imagenes;
                        repeterImagenes.DataBind();
                        repeterImagenesInd.DataSource = articulo.Imagenes;
                        repeterImagenesInd.DataBind();  
                    }
                    else
                    {
                        List<Imagen> imagenesDefault = new List<Imagen>
                            {
                                new Imagen {  UrlImagen = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" }
                            };
                        repeterImagenes.DataSource = imagenesDefault;
                        repeterImagenes.DataBind();
                        repeterImagenesInd.DataSource= imagenesDefault;
                        repeterImagenesInd.DataBind() ;
                         }
                }
            }
        }


        private void cargarArticulo(int idArticulo)
        {

            ArticuloNegocio artNegocio = new ArticuloNegocio();
            articulo = artNegocio.listar().FirstOrDefault(a => a.IdArticulo == idArticulo);

            // Si el artículo existe
            if (articulo != null)
            {
                // Se asignan los valores a los controles del formulario
               
            }
        }
    }
}
