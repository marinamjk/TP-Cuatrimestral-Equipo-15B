using Negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Presentacion
{
    public partial class AdministrarMarca : System.Web.UI.Page
    {
        protected int id;
        Marca marca;
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
            
    
        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                int index;
                if (int.TryParse(e.CommandArgument.ToString(), out index))
                {
                    if (index >= 0 && index < dgvMarcas.DataKeys.Count)
                    {
                        id = int.Parse(dgvMarcas.DataKeys[index].Value.ToString());
                    }
                }

                if (e.CommandName == "Modificar")
                {
                    btnAgregar.Text = "Modificar";
                    marca = marcaNegocio.listarMarcas().Find(m => m.IdMarca == id);
                    Session.Add("marcaSeleccionada", marca); 
                    txtNombre.Text = marca.Nombre;
                }
                else if (e.CommandName == "Eliminar")
                {
                    marcaNegocio.eliminarMarca(id);
                    CargarGridView();
                }
            }
            catch(SqlException sq)
            {
                Session.Add("Error", "No se puede eliminar esta marca porque está siendo utilizada.");
                Response.Redirect("Error.aspx");
            }
            catch (Exception ex) 
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }

        }

        protected void dgvMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMarcas.PageIndex = e.NewPageIndex;
                     
            CargarGridView();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();

                if (Session["marcaSeleccionada"] != null)
                {
                    marca = (Marca)Session["marcaSeleccionada"];
                    marca.Nombre = txtNombre.Text;
                    marcaNegocio.modificarMarca(marca);
                    txtNombre.Text = string.Empty;
                    btnAgregar.Text = "Agregar";
                    Session["marcaSeleccionada"] = null;
                }
                else
                {
                    marca = new Marca();
                    marca.Nombre = txtNombre.Text;
                    marcaNegocio.agregarMarca(marca);
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
            btnAgregar.Text = "Agregar";
        }
    }
}
