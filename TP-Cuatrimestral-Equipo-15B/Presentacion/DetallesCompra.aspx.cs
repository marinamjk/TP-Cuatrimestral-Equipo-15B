﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class DetallesCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMediosDePago_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CheckOut.aspx");
        }
    }
}