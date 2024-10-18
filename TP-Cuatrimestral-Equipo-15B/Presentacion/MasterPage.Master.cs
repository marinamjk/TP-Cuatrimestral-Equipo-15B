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
        
             Inicio = "Iniciar Sesión";
            //si hay un usuario ingresado cambiar Inicio a nombre de usuario
          
        }
    }
}