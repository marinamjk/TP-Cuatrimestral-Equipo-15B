using dominio;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Web.UI.WebControls.WebParts;

namespace Presentacion
{
    //Declara list de enteros
    public partial class AltaModArticulo : System.Web.UI.Page
    {
        List<Imagen> images;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    images = new List<Imagen>();
                    Session["ImagesList"] = images;

                    List<Categoria> subcategorias = new List<Categoria>();
                    CategoriaNegocio catNegocio = new CategoriaNegocio();
                    subcategorias = catNegocio.listarUltimasSubcategorias();

                    ddlCategoria.DataSource = subcategorias;
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataBind();

                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    ddlMarca.DataSource = marcaNegocio.listarMarcas();
                    ddlMarca.DataValueField = "IdMarca";
                    ddlMarca.DataTextField = "Nombre";
                    ddlMarca.DataBind();



                    if (Request.QueryString["idArt"] != null)
                    {
                        int idArtMod = int.Parse(Request.QueryString["idArt"]);
                        ArticuloNegocio artNegocio = new ArticuloNegocio();
                        ImagenNegocio imNegocio = new ImagenNegocio();
                        Articulo artMod = artNegocio.buscarArticuloXId(idArtMod);

                        txtNombre.Text = artMod.Nombre;
                        txtDescripcion.Text = artMod.Descripcion;
                        txtPrecio.Text = artMod.Precio.ToString("F2");
                        txtStock.Text = artMod.Stock.ToString();
                        ddlCategoria.SelectedValue = artMod.Categoria.IdCategoria.ToString();
                        ddlMarca.SelectedValue = artMod.Marca.IdMarca.ToString();
                                                
                        images = imNegocio.buscarImagenesXArticulo(idArtMod);
                        Session["ImagesList"] = images;
                        //cargarlistadecategoriasSeleccionada();
                        //RecontruirDesplegablesCategorias();                                 
                    }
                    CargarImagenes();
                }

                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                ArticuloNegocio artNegocio = new ArticuloNegocio();
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                Articulo nuevo = new Articulo();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Marca = new Marca();
                nuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Stock = int.Parse(txtStock.Text);
                nuevo.Puntaje = 0;

                int idNuevo;
                if (Request.QueryString["idArt"] != null)
                {
                    idNuevo = int.Parse(Request.QueryString["idArt"]);
                    nuevo.IdArticulo = idNuevo;
                    artNegocio.modificarArticulo(nuevo);
                }
                else
                {
                    idNuevo = artNegocio.agregarArticulo(nuevo);
                }

                if (Request.QueryString["idArt"] != null)
                {
                    imagenNegocio.eliminarImagenesXIDArticulo(idNuevo);
                }

                nuevo.Imagenes = (List<Imagen>)Session["ImagesList"];                

                if (nuevo.Imagenes != null && nuevo.Imagenes.Count > 0)
                {
                    for (int i = 0; i < nuevo.Imagenes.Count; i++)
                    {
                        nuevo.Imagenes[i].IdArticulo = idNuevo;
                        imagenNegocio.agregarImagen(nuevo.Imagenes[i]);
                    }
                }



                Response.Redirect("~/Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //if (!(revUrlImagen.IsValid))
            //{
            //    return;
            //}
            try
            {
                string url = txtUrlImagen.Text;

                images = (List<Imagen>)Session["ImagesList"];
                if (images == null)
                {
                    images = new List<Imagen>();
                }

                images.Add(new Imagen { UrlImagen = url });

                Session["ImagesList"] = images;
                RepeaterImages.DataSource = images;
                RepeaterImages.DataBind();

                txtUrlImagen.Text = string.Empty;
                CargarImagenes();
            }
            catch (Exception ex) 
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
                       
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
            CargarImagenes();
        }
        private void CargarImagenes()
        {
            List<Imagen> images = (List<Imagen>)Session["ImagesList"];
           
            RepeaterImages.DataSource = images;
            RepeaterImages.DataBind();
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {     
            imgArticulo.ImageUrl = txtUrlImagen.Text;          
        }
          

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx", false);
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //guardarIDseleccionado en lista de categoriasSeleccionadas
            //Chequer si la subcategoria seleccionada tiene como idPadre algunas de las
            //categoriasSeleccionadas, si es asi eliminar las siguiente subcategorias
            //y generar un nuevo dropdown
            //CategoriaNegocio catNegocio= new CategoriaNegocio();
            //int? catPadre = catNegocio.buscarCategoriaXId(idCategoriaSeleccionada).IDCategoriaPadre;
            //if(categoriasSeleccionadas.Count>0){
            //  int i;
            //  for(i=0; i<categoriasSeleccionadas.Count-1; i++){

            //  if(categoriasSeleccionadas[i]==catPadre)
            //  break;
            //  }
            // for(int j=categoriasSeleccionadas.Count; j=i; j++){
            //  categoriasSeleccionadas.RemoveAt(j);    
            //}
            //este o no este la categoria padre ya en un dropdown la agrego para listar las subcategorias
            //CategoriasSeleccionada.Add(idCategoriaSeleccionada);
            //RecontruirDesplegablesCategorias();
        }

        /*RecontruirDesplegablesCategorias(){
        CategoriaNegocio catNegocio= new CategoriaNegocio();
        for(int i=0; i<categoriasSeleccionadas.Count; i++){
        Crear un dropdown
        if(catNegocio.listarSubcategorias.Any()){
        CrearDropdown       
        }
         ddlCategoria.selectedValue= CategoriasSeleccionas[0].toString();
        for(int i=1; i<categoriasSeleccionadas.Count-1; i++){
         categoriasSeleccionadas[i].SelectedValue= categoriasSeleccionadas[i+1]
        }
        }
        */
        /*cargarlistadecategoriasSeleccionada(){
         * catnegocio
         * buscarCategoriaPadre hasta que el idCategoriaPadre==null
         * guardarlos en una lista aux
         * y guardarlos en listade categorias seleccionadas en orden contrario
         * 
        */

    }
}
