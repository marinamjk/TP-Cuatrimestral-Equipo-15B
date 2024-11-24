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
                EmailService emailService = new EmailService();
                usuario.Mail = txtEmail.Text;
                string contrasenia= string.Empty;
                
                if (txtContraseña.Text == txtContraseña2.Text && txtContraseña.Text != string.Empty)
                {
                    contrasenia = txtContraseña.Text;
                } else
                {
                    Session.Add("error", "Las contraseñas no coinciden o no son válidas, por favor, vuelva a intentarlo");
                    Response.Redirect("Error.aspx", false);
                    return;
                }
                usuario.Contraseña = contrasenia;
                usuario.Estado = true;
               
                var usuarioExistente = um.listarUsuarios().FirstOrDefault(u => u.Mail == usuario.Mail && u.Estado == false);

                if (usuarioExistente != null)
                {              
                    um.ModificarEstadoUsuario(usuarioExistente.IdUsuario, true);
                    um.modificarContrasenia(usuarioExistente, contrasenia);
                    Session.Add("usuario", usuarioExistente);
                }
                else
                {
                    usuario.IdUsuario = um.agregarUsuario(usuario);
                    Session.Add("usuario", usuario);
                }
               
                
                emailService.armarCorreo(usuario.Mail, "Bienvenida", "Hola, Te has registrado exitosamente a nuestra pagina. <div>Su usuario es: "+ usuario.Mail+"</div><div>Su contraseña es: "+ usuario.Contraseña+"</div>");
                emailService.enviarEmail();

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