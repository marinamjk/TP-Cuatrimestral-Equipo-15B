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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioManager agregar = new UsuarioManager();
            try
            {
                usuario.Contraseña = TbContraseña.Text;
                usuario.Mail = TbMail.Text;
                if(usuario.Contraseña == TbConfirmaContraseña.Text && usuario.Mail != "")
                {
                    usuario.Nombre = TbNombre.Text;
                    usuario.Apellido = TbApellido.Text;
                    usuario.Dni = TbDocumento.Text;
                    usuario.telefono = TbTelefono.Text;
                    agregar.agregarUsuario(usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Response.Redirect("Registrarse.aspx", false);
                }
            }
            catch (Exception ex)
            {

                 throw ex;
            }
        }
    }
}