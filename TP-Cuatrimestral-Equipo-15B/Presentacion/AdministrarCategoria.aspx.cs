using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class AdministrarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridView();
            }
        }

        private void CargarGridView()
        {
            DataTable datosPrueba = new DataTable();
            datosPrueba.Columns.Add("Codigo");
            datosPrueba.Columns.Add("NombreArticulo");
            datosPrueba.Columns.Add("Cantidad");
            datosPrueba.Columns.Add("Precio");

            datosPrueba.Rows.Add(1, "Teclado", 2, 200000.00);
            datosPrueba.Rows.Add(2, "Mouse", 1, 30000.00);

            dgvArticulos.DataSource = datosPrueba;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }



}