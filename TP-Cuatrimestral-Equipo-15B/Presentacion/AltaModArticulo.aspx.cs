using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class AltaModArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ImageLinks"] = new List<string>();
                BindRepeater();
            }
        }


        protected void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
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

            // Recuperar la lista de links desde el ViewState
            List<string> imageLinks = (List<string>)ViewState["ImageLinks"];

            // Agregar el nuevo link si el TextBox no está vacío
            if (!string.IsNullOrWhiteSpace(txtUrlImagen.Text))
            {
                imageLinks.Add(txtUrlImagen.Text);

                // Guardar la lista actualizada en el ViewState
                ViewState["ImageLinks"] = imageLinks;

                // Actualizar el Repeater
                BindRepeater();

                // Limpiar el TextBox
                txtUrlImagen.Text = string.Empty;
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            // Recuperar la lista de links desde el ViewState
            List<string> imageLinks = (List<string>)ViewState["ImageLinks"];

            // Obtener el índice del botón que fue clickeado
            Button btn = (Button)sender;
            int index = int.Parse(btn.CommandArgument);

            // Eliminar la imagen de la lista
            if (index >= 0 && index < imageLinks.Count)
            {
                imageLinks.RemoveAt(index);
            }

            // Guardar la lista actualizada en el ViewState
            ViewState["ImageLinks"] = imageLinks;

            // Actualizar el Repeater
            BindRepeater();

        }
        private void BindRepeater()
        {
            // Recuperar la lista de links desde el ViewState y enlazarla al Repeater
            List<string> imageLinks = (List<string>)ViewState["ImageLinks"];
            RepeaterImages.DataSource = imageLinks.Select(link => new { Url = link }).ToList();
            RepeaterImages.DataBind();
        }

    }
}