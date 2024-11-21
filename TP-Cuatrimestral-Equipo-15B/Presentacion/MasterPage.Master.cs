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
            if (!Seguridad.sesionActiva(Session["usuario"])) 
            {
                Inicio = "Iniciar Sesión";
                ImagenPerfil.ImageUrl = "Recursos/usuario.png";
            }
            else
            {
                if (((Usuario)Session["usuario"]).Nombre != null)
                {
                    Inicio = ((Usuario)Session["usuario"]).Nombre;
                }
                else
                {
                    int index = ((Usuario) Session["usuario"]).Mail.IndexOf("@");
                    string nombre = ((Usuario)Session["usuario"]).Mail.Substring(0,index);
                    Inicio = nombre;
                }

                if (((Usuario)Session["usuario"]).Foto != null)
                {
                    ImagenPerfil.ImageUrl = ((Usuario)Session["usuario"]).Foto;
                }     
              
            }
            //si hay un usuario ingresado cambiar Inicio a nombre de usuario

            if(!(Page is Login || Page is Default || Page is Error || Page is Registrarse || Page is Detalle || Page is Carrito || Page is MetodosPago || Page is DatosContacto || Page is ConfirmacionCompra))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                {
                    Response.Redirect("login.aspx", false);
                }

                if (Page is AdministrarArticulos || Page is AdministrarCategoria || Page is AdministrarColeccion || Page is AltaModArticulo || Page is AdministrarPedido || Page is ListaPedidos)
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
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }  
    }
}