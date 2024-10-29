﻿using dominio;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class AltaModArticulo : System.Web.UI.Page
    {
        int idCategoriaSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    ViewState["CategoriasSeleccionadas"] = new List<int>();
                    //CargarImagenes();

                    CategoriaNegocio catNegocio = new CategoriaNegocio();

                    ddlCategoria.DataSource = catNegocio.listarSubcategorias(null);
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataBind();

                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    ddlMarca.DataSource = marcaNegocio.listarMarcas();
                    ddlMarca.DataValueField = "IdMarca";
                    ddlMarca.DataTextField = "Nombre";
                    ddlMarca.DataBind();

                }
                else
                {
                    List<int> categoriasSeleccionadas = (List<int>)ViewState["CategoriasSeleccionadas"];
                    foreach (int idCategoria in categoriasSeleccionadas)
                    {
                        CargarSubcategoria(idCategoria);
                    }
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

                Articulo nuevo = new Articulo();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Marca = new Marca();
                nuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);
                nuevo.Descripcion = txtDescripción.Text;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Stock = int.Parse(txtStock.Text);
                nuevo.Puntaje = 0;
                int idNuevo = artNegocio.agregarArticulo(nuevo);

                nuevo.Imagenes = (List<Imagen>)Session["ImagesList"];
                ImagenNegocio imagenNegocio = new ImagenNegocio();

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
            revUrlImagen.Validate();
            if (!revUrlImagen.IsValid)
            {
                txtUrlImagen.Text = string.Empty;
                return;
            }
            string urlImagen = txtUrlImagen.Text;

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
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx", false);
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idCategoriaSeleccionada = int.Parse(((DropDownList)sender).SelectedValue);

                DropDownList ddlSender = (DropDownList)sender;
               
                // Guarda la categoría seleccionada en ViewState
                List<int> categoriasSeleccionadas = (List<int>)ViewState["CategoriasSeleccionadas"];
                if (!categoriasSeleccionadas.Contains(idCategoriaSeleccionada))
                {
                    categoriasSeleccionadas.Add(idCategoriaSeleccionada);
                    ViewState["CategoriasSeleccionadas"] = categoriasSeleccionadas;
                }

                // Cargar las subcategorías correspondientes
                CargarSubcategoria(idCategoriaSeleccionada);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
        private void CargarSubcategoria(int idCategoriaSeleccionada)
        {
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            List<Categoria> subcategorias = catNegocio.listarSubcategorias(idCategoriaSeleccionada);

            if (subcategorias != null && subcategorias.Count > 0)
            {
                DropDownList nuevoDdl = new DropDownList
                {
                    ID = $"ddlSubcategoria_{idCategoriaSeleccionada}",
                    AutoPostBack = true
                };

                nuevoDdl.SelectedIndexChanged += ddlCategoria_SelectedIndexChanged;

                nuevoDdl.DataSource = subcategorias;
                nuevoDdl.DataTextField = "Nombre";
                nuevoDdl.DataValueField = "IdCategoria";
                nuevoDdl.DataBind();

                phSubcategorias.Controls.Add(nuevoDdl);
            }


        }
    }
}
