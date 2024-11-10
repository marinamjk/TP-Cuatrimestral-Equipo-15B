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
    public partial class AdministrarColeccion : System.Web.UI.Page
    {
        protected int id;
        Coleccion col;
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
                ColeccionNegocio cn = new ColeccionNegocio();
                dgvColecciones.DataSource = cn.listarColecciones();
                dgvColecciones.DataBind();
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
                ColeccionNegocio cn= new ColeccionNegocio();

                if (Session["ColeccionSeleccionada"] != null)
                {
                    col = (Coleccion)Session["ColeccionSeleccionada"];
                    col.Nombre = txtNombre.Text;
                    cn.modificarColeccion(col);
                    txtNombre.Text = string.Empty;
                    btnAgregar.Text = "Agregar";
                    Session["ColeccionSeleccionada"] = null;
                }
                else
                {
                    col = new Coleccion();
                    col.Nombre = txtNombre.Text;
                    cn.agregarColeccion(col);
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
            Session["ColeccionSeleccionada"] = null;
            txtNombre.Text = string.Empty;
            btnAgregar.Text = "Agregar";
        }

        protected void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
     
            ColeccionNegocio cn= new ColeccionNegocio();
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            int itemId = Convert.ToInt32(dgvColecciones.DataKeys[row.RowIndex].Value);
            bool nuevoEstado = chk.Checked;
            cn.eliminarColeccionLogicamente(itemId, nuevoEstado);
          
        }

        protected void dgvColecciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ColeccionNegocio cn = new ColeccionNegocio();

            try
            {
                int index;
                if (int.TryParse(e.CommandArgument.ToString(), out index))
                {
                    if (index >= 0 && index < dgvColecciones.DataKeys.Count)
                    {
                        id = int.Parse(dgvColecciones.DataKeys[index].Value.ToString());
                    }
                }

                if (e.CommandName == "Modificar")
                {
                    btnAgregar.Text = "Modificar";
                    col = cn.listarColecciones().Find(c => c.IdColeccion == id);
                    Session.Add("ColeccionSeleccionada", col);
                    txtNombre.Text = col.Nombre;
                }

            }
            catch (SqlException sq)
            {
                Session.Add("Error", "No se puede eliminar esta Coleccion porque está siendo utilizada.");
                Response.Redirect("Error.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }

        }

        protected void dgvColecciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvColecciones.PageIndex = e.NewPageIndex;

            CargarGridView();
        }
    }
}
