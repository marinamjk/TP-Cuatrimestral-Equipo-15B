using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using dominio;
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
            int id = 0;
            Usuario usuario = new Usuario();
            Usuario usuarioCargado = new Usuario();
            UsuarioManager usuarioManager = new UsuarioManager();
            usuario.Mail = TbMail.Text;
            usuario.Contraseña = TbContraseña.Text;
            usuarioCargado = usuarioManager.iniciar_sesion(usuario);
            if(usuarioCargado != null)
            {
                Session.Add("usuario", usuarioCargado);
                Response.Redirect("default.aspx", false);
            }
            else
            {
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}