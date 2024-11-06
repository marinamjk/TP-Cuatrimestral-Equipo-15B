using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Presentacion
{
    public partial class AdministrarCategoria : System.Web.UI.Page
    {
        protected int id;
        Categoria categoria;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();
                CargarDesplegableCat();
            }

        }

        private void CargarDesplegableCat()
        {
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            ddlCategoriasPadre.DataSource = catNegocio.listarCategorias();
            ddlCategoriasPadre.DataValueField = "IdCategoria";
            ddlCategoriasPadre.DataTextField = "Nombre";
            ddlCategoriasPadre.DataBind();
        }

        private void CargarGridView()
        {
            try
            {
                CategoriaNegocio catNegocio = new CategoriaNegocio();
                dgvCategorias.DataSource = catNegocio.listarCategorias();
                dgvCategorias.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategorias.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        protected void dgvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            CategoriaNegocio catNegocio = new CategoriaNegocio();

            try
            {
                int index;
                if (int.TryParse(e.CommandArgument.ToString(), out index))
                {
                    if (index >= 0 && index < dgvCategorias.DataKeys.Count)
                    {
                        id = int.Parse(dgvCategorias.DataKeys[index].Value.ToString());
                    }
                }               

                if (e.CommandName == "Modificar")
                {
                    btnAgregar.Text = "Modificar";
                    categoria = catNegocio.buscarCategoriaXId(id);
                    txtNombre.Text = categoria.Nombre;
                    if (categoria.IDCategoriaPadre != null)
                    {
                        ddlCategoriasPadre.SelectedValue = categoria.IDCategoriaPadre.ToString();
                    }
                    else
                    {
                        chkSinCat.Checked = true;
                    }

                    Session.Add("categoriaSeleccionada", categoria);
                }
                else if (e.CommandName == "Eliminar")
                {
                    catNegocio.eliminarCategoria(id);
                    CargarGridView();
                }
            }
            catch (SqlException sq)
            {
                Session.Add("Error", "No se puede eliminar esta categoria porque está siendo utilizada.");
                Response.Redirect("Error.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio catNegocio = new CategoriaNegocio();

                if (Session["categoriaSeleccionada"] != null)
                {
                    categoria = (Categoria)Session["categoriaSeleccionada"];
                    categoria.Nombre = txtNombre.Text;
                    if (!chkSinCat.Checked)
                    {
                        categoria.IDCategoriaPadre = int.Parse(ddlCategoriasPadre.SelectedValue.ToString());
                    }
                    else
                    {
                        categoria.IDCategoriaPadre = null;
                    }

                    catNegocio.modificarCategoria(categoria);
                    btnAgregar.Text = "Agregar";
                    txtNombre.Text = string.Empty;
                    Session["marcaSeleccionada"] = null;

                }
                else
                {
                    categoria = new Categoria();
                    categoria.Nombre = txtNombre.Text;
                    if (!chkSinCat.Checked)
                    {
                        categoria.IDCategoriaPadre = int.Parse(ddlCategoriasPadre.SelectedValue.ToString());
                    }
                    else
                    {
                        categoria.IDCategoriaPadre = null;
                    }
                    catNegocio.agregarCategoria(categoria);
                    txtNombre.Text = string.Empty;
                }
                CargarGridView();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["marcaSeleccionada"] = null;
            txtNombre.Text = string.Empty;
            ddlCategoriasPadre.SelectedIndex = 0;
            chkSinCat.Checked = false;
            btnAgregar.Text = "Agregar";
        }
    }



}