using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using dominio;
using Negocio;

namespace Presentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtAceptar_Click(object sender, EventArgs e)
        {
            //int id = 0;
            //Usuario usuario = new Usuario();
            //Usuario usuarioCargado = new Usuario();
            //UsuarioManager usuarioManager = new UsuarioManager();
            //usuario.Mail = TbMail.Text;
            //usuario.Contraseña = TbContraseña.Text;
            //usuarioCargado = usuarioManager.iniciar_sesion(usuario);
            //if (usuarioCargado != null)
            //{
            //    Session.Add("usuario", usuarioCargado);
            //    Response.Redirect("default.aspx", false);
            //}
            //else
            //{
            //    Response.Redirect("Error.aspx", false);
            //}

            Usuario usuario = new Usuario();
            UsuarioManager usuarioManager = new UsuarioManager();

            try
            {
                usuario.Mail = TbMail.Text;               
                usuario.Contraseña = TbContraseña.Text;            

                if (usuarioManager.loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("error", "Email o contraseña incorrectos, por favor intente nuevamente");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex) 
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }                        
         
        }
    }
}