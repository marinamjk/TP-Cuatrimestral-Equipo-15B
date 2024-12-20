﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using Negocio;
using System.Web.UI.WebControls.WebParts;

namespace Presentacion
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected Articulo articulo;
        protected string nombreArt;
        protected string marcaArt;
        protected string descripcionArt;
        protected string CategoriaArt;
        protected int idArticulo;
        protected bool esFavorito;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                
                if (!IsPostBack)
                {
               
                    string idQuery = Request.QueryString["id"];
                   
                    if (!string.IsNullOrEmpty(idQuery) && int.TryParse(idQuery, out idArticulo))
                    {

                        cargarArticulo(idArticulo);

                        if (articulo != null)
                        {
                            Session["ArticuloSeleccionado"] = articulo; 
                            CargarImagenes();
                            if (!articulo.Estado)
                            {
                                btnDeshabilitar.Text = "Habilitar";
                            }
                            actualizarEstadoFavorito();
                        }
                        else
                        {
                            lblConfirmacion.Text = "El artículo no existe.";
                        }

                    }
                    else
                    {
                        lblConfirmacion.Text = "El ID del artículo no es válido.";
                    }
                                      

                }
                else
                {
                    articulo = (Articulo)Session["ArticuloSeleccionado"];
                    actualizarEstadoFavorito();
                }
                

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

       
        }

        private void CargarImagenes()
        {
            if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
            {
                repeterImagenes.DataSource = articulo.Imagenes;
                repeterImagenes.DataBind();
                repeterImagenesInd.DataSource = articulo.Imagenes;
                repeterImagenesInd.DataBind();
            }
            else
            {
                List<Imagen> imagenesDefault = new List<Imagen>{new Imagen {UrlImagen = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"}};
                repeterImagenes.DataSource = imagenesDefault;
                repeterImagenes.DataBind();
                repeterImagenesInd.DataSource = imagenesDefault;
                repeterImagenesInd.DataBind();
            }
        }

        private void cargarArticulo(int idArticulo)
        {

            try
            {
                ArticuloNegocio artNegocio = new ArticuloNegocio();
                articulo = artNegocio.listarConSP().FirstOrDefault(a => a.IdArticulo == idArticulo);
                

                if (articulo != null)
                {

                    nombreArt = articulo.Nombre.ToString();
                    marcaArt = articulo.Coleccion.Nombre;
                    descripcionArt = articulo.Descripcion;
                    lblPuntaje.Text = "Puntaje: " + articulo.Puntaje.ToString("F2");
                    lblPrecio.Text = "$" + (articulo.Precio).ToString("F2");
                    lblStockDisponible.Text = "Stock: " + articulo.Stock.ToString();
                    lblCategoria.Text = listarRamaCategorias();                    
                }
            }
            catch(Exception ex) 
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
           
        }
       
        protected void Modificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaModArticulo.aspx?idArt="+ articulo.IdArticulo);
        }

        protected string listarRamaCategorias()
        {
            string rama="";         
            CategoriaNegocio catNegocio= new CategoriaNegocio();
            Categoria cat= new Categoria();
            int? catPadre;
            try
            {
                
                cat = catNegocio.buscarCategoriaXId(articulo.Categoria.IdCategoria);
                catPadre = cat.IDCategoriaPadre;
                rama = cat.Nombre;

                while (catPadre.HasValue && catPadre != 0)
                {
                    cat = catNegocio.buscarCategoriaXId(catPadre);
                    rama = cat.Nombre + " > "+ rama;
                    catPadre= cat.IDCategoriaPadre;
                }
        
               
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
                        
            return rama;
        }

        protected void btnIrAlCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (articulo != null)
                {
                    int cantidad;

                    //Response.Write($"Cantidad ingresada: {txtCantidad.Text}<br />");

                    //if (int.TryParse(txtCantidad.Text, out cantidad) && cantidad > 0 && cantidad <= articulo.Stock)
                    //{
                    //    CarritoNegocio carritoNegocio = new CarritoNegocio();
                    //    carritoNegocio.AgregarAlCarrito(articulo, cantidad);
                    //    lblConfirmacion.Text = "Articulo agregado al carrito";
                    //}
                    if (int.TryParse(txtCantidad.Text, out cantidad) && cantidad > 0 && cantidad <= articulo.Stock)
                    {
                        // uso la misma instancia de carritosnegocio que maneja la sesión
                        CarritoNegocio carritoNegocio = new CarritoNegocio();
                        carritoNegocio.AgregarAlCarrito(articulo, cantidad);
                        lblConfirmacion.Text = "Artículo agregado al carrito.";
                    }
                    else
                    {
                        // Response.Write($"Cantidad inválida ingresada: {cantidad}. Stock disponible: {articulo.Stock}<br />");

                        lblConfirmacion.Text = "Cantidad Invalida ingrese un numero entre 1 y " + articulo.Stock;
                    }
                }
                else
                {
                    //Response.Write("Error: El artículo es nulo.<br />");
                    lblConfirmacion.Text = "Error al agregar articulo al carrito";
                }
            }
            catch (Exception ex)
            {
                //Response.Write($"Error al cargar al carrito: {ex.Message}<br />");
                Session.Add("error al cargar al carrito", ex.ToString());
                lblConfirmacion.Text = "Error al cargar al carrito: " + ex.Message;
            }
        }

        protected void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio artNegocio = new ArticuloNegocio();                
                artNegocio.eliminarArticuloLogicamente(articulo.IdArticulo, !articulo.Estado);
                Response.Redirect("~/Default.aspx", false);
            }catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    Usuario user = (Usuario)Session["usuario"];
                    if (user != null && Request.QueryString["id"] != null)
                    {
                        int idUser = user.IdUsuario;
                        int idArt = int.Parse(Request.QueryString["id"]);

                        AgregadosNegocio ag = new AgregadosNegocio();
                                              
                        if (!esFavorito)
                        {
                            ag.agregarAFavoritos(idUser, idArt);
                            esFavorito = true;
                        }
                        else
                        {
                            ag.eliminarDeFavoritos(idUser, idArt);
                            esFavorito = false;
                        }                     
                        
                    }
                }
                else
                {
                    Session.Add("error", "Debes loguearte para añadir a Favoritos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void actualizarEstadoFavorito()
        {
            AgregadosNegocio ag = new AgregadosNegocio();
            if (Session["usuario"] != null)
            {
                int idUsuario = ((Usuario)Session["usuario"]).IdUsuario;
                if ((ag.listarFavoritos(idUsuario).Any(c => c.IdArticulo == articulo.IdArticulo)))
                    esFavorito = true;
                else
                    esFavorito = false;
                
            }

        }
    }
}
