﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Presentacion
{
	public partial class MiPerfil : System.Web.UI.Page
	{
        public string titulo;
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Seguridad.sesionActiva(Session["usuario"])){            
                Usuario us = (Usuario)Session["usuario"];
                titulo = us.Nombre;
            }
            TbNombre.Enabled = false;
            TbApellido.Enabled = false;
            TbDocumento.Enabled = false;
            TbTelefono.Enabled = false;
            txtCalle.Enabled = false;
            txtCodigoPostal.Enabled = false;
            txtLocalidad.Enabled = false;
            txtNumero.Enabled = false;
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

        protected void BtModificar_click(object sender, EventArgs e)
        {
            ((Usuario)Session["usuario"]).modificar = true;
            TbNombre.Enabled = true;
            TbApellido.Enabled = true;
            TbDocumento.Enabled = true;
            TbTelefono.Enabled = true;
            txtCalle.Enabled = true;
            txtCodigoPostal.Enabled = true;
            txtLocalidad.Enabled = true;
            txtNumero.Enabled = true;
        }
    }
}