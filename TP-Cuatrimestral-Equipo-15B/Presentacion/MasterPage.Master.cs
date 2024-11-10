using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class MasterPage : System.Web.UI.MasterPage
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
                Inicio = ((Usuario)Session["usuario"]).Nombre;
            }
            //si hay un usuario ingresado cambiar Inicio a nombre de usuario

            if(!(Page is Login || Page is Default || Page is Error || Page is Registrarse || Page is Detalle || Page is Carrito))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("login.aspx", false);
                }

                if (Page is AdministrarArticulos || Page is AdministrarCategoria || Page is AdministrarColeccion || Page is AltaModArticulo || Page is AdministrarPedido)
                {
                    if (!Seguridad.esAdministrador(Session["usuario"]))
                    {
                        Session.Add("Error", "Se requiere permisos de administrador para acceder a esta pantalla");
                        Response.Redirect("Error.aspx", false);

                    }
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Default.aspx", false);
        }
    }
}