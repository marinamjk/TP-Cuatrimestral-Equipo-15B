using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;
using static System.Net.WebRequestMethods;

namespace Presentacion
{
	public partial class MiPerfil : System.Web.UI.Page
	{
        public string titulo;
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Seguridad.sesionActiva(Session["usuario"])){            
                Usuario us = (Usuario)Session["usuario"];
                titulo = us.Nombre;
                TbNombre.Text = us.Nombre;
                TbApellido.Text = us.Apellido;
            }
            TbNombre.Enabled = false;
            TbApellido.Enabled = false;
            TbDocumento.Enabled = false;
            TbTelefono.Enabled = false;
            txtCalle.Enabled = false;
            txtCodigoPostal.Enabled = false;
            txtLocalidad.Enabled = false;
            txtNumero.Enabled = false;
		}

        protected void btnAgregarDireccion_Click(object sender, EventArgs e)
        {

        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtModificar_click(object sender, EventArgs e)
        {
            ((Usuario)Session["usuario"]).modificar = true;
            TbNombre.Enabled = true;
            TbApellido.Enabled = true;
            TbDocumento.Enabled = true;
            TbTelefono.Enabled = true;
            txtCalle.Enabled = true;
            txtCodigoPostal.Enabled = true;
            txtLocalidad.Enabled = true;
            txtNumero.Enabled = true;
        }

        protected void BtAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario = ((Usuario)Session["usuario"]);
            UsuarioManager Usuarios = new UsuarioManager();
            usuario.Nombre = "hola";
            usuario.Apellido = TbApellido.ToString();
            usuario.Dni = TbDocumento.Text;
            usuario.telefono = TbTelefono.Text;
            usuario.Foto = "https://imgs.search.brave.com/-BtlJWfCZK6-fD12f_E5yeLNpr21GR9F3GZBvDPuKdY/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZW5lc2Jvbml0YXMu/Ym9zcXVlZGVmYW50/YXNpYXMuY29tL3dw/LWNvbnRlbnQvdXBs/b2Fkcy8yMDE1LzA5/L2ZvdG9zLWRlLWdv/a3UtNDAweDI4NC5q/cGc";
            if(usuario.IdDatosPersonales == null)
            {
                Usuarios.agregarDatosPersonales(usuario);
                Session["usuario"] = usuario;
                Response.Redirect("MiPerfil.aspx", false);
            }
            else
            {
                Usuarios.ModificarDatosPersonales(usuario);
                Session["usuario"] = usuario;
                Response.Redirect("MiPerfil.aspx", false);
            }
        }
    }
}