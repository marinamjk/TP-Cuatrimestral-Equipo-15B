using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoADatos;
using dominio;
using domino;
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
            UsuarioManager usuarioManager = new UsuarioManager();
            usuario.Mail = TbMail.Text;
            usuario.Contraseña = TbContraseña.Text;
            id = usuarioManager.iniciar_sesion(usuario);
            if(id > 0)
            {
                Session.Add("usuario", usuario);
                Response.Redirect("default.aspx", false);
            }
            else
            {
                Response.Redirect("historial.aspx",false);
            }
        }
    }
}