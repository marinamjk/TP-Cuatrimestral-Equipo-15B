using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string Inicio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null ) 
            {
                Inicio = "Iniciar Sesión";
            }
            else
            {
                int index = ((Usuario) Session["usuario"]).Mail.IndexOf("@");
                string nombre = ((Usuario)Session["usuario"]).Mail.Substring(0,index);
                Inicio = nombre;
            }
            //si hay un usuario ingresado cambiar Inicio a nombre de usuario
          
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Default.aspx", false);
        }
    }
}