using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domino;
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
                usuario.Nombre = TbNombre.Text;
                usuario.Apellido = TbApellido.Text;
                usuario.Mail = TbMail.Text;
                usuario.Dni = TbDocumento.Text;
                usuario.Contraseña = TbContraseña.Text;
                usuario.telefono = TbTelefono.Text;
                agregar.agregarUsuario(usuario);
            }
            catch (Exception ex)
            {

                 throw ex;
            }
        }
    }
}