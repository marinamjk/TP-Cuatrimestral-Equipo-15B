﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace Presentacion
{
	public partial class Mi_perfil : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
			if (usuario == null)
			{
				Response.Redirect("login.aspx");
			}
		}

        protected void btnAgregarDireccion_Click(object sender, EventArgs e)
        {

        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}