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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void BtAceptar_Click(object sender, EventArgs e)
        //{
            //Usuario usuario = new Usuario();
            //UsuarioManager agregar = new UsuarioManager();
            //try
            //{
            //    usuario.Contraseña = TbContraseña.Text;
            //    usuario.Mail = TbMail.Text;
            //    if(usuario.Contraseña == TbConfirmaContraseña.Text && usuario.Mail != "")
            //    {
            //        usuario.Nombre = TbNombre.Text;
            //        usuario.Apellido = TbApellido.Text;
            //        usuario.Dni = TbDocumento.Text;
            //        usuario.telefono = TbTelefono.Text;
            //        agregar.agregarUsuario(usuario);
            //        Response.Redirect("Default.aspx", false);
            //    }
            //    else
            //    {
            //        Response.Redirect("Registrarse.aspx", false);
            //    }
            //}
            //catch (Exception ex)
            //{

            //     throw ex;
            //}
        //}
   

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioManager um = new UsuarioManager();
                usuario.Mail = txtEmail.Text;
                if (txtContraseña.Text == txtContraseña2.Text && txtContraseña.Text != string.Empty)
                {
                    usuario.Contraseña = txtContraseña.Text;
                }
                int id = um.agregarUsuario(usuario);
                //enviar email de bienvenida

                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}