using Negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class DatosContacto : System.Web.UI.Page
    {
        private CarritoNegocio carritoNegocio;
        private ProvinciaNegocio provinciaNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            carritoNegocio = new CarritoNegocio();
            provinciaNegocio = new ProvinciaNegocio();

            if (!IsPostBack)
            {
                //// Inicializa los valores si es la primera carga
                //DatosDestinatario.Visible = false;
                //DatosFacturacion.Visible = false;
                CargarResumenCompra();
                CargarProvincias();
            }
        }

        private void CargarResumenCompra()
        {
            var articulosCarrito = carritoNegocio.ObtenerAticulos();
            decimal calculoTotal = carritoNegocio.ObtenerTotal();

            if (articulosCarrito != null && articulosCarrito.Any())
            {

                lblTotal.Text = $"${calculoTotal:N2}";
                rptResumenCarrito.DataSource = articulosCarrito;
                rptResumenCarrito.DataBind();
            }
            else
            {
                lblTotal.Text = "$0.00";
            }
        }

        private void CargarProvincias()
        {
            List<Provincia> provincias = provinciaNegocio.ObtenerProvincias();
            DropDownListProvincia.DataSource = provincias;
            DropDownListProvincia.DataTextField = "Nombre";
            DropDownListProvincia.DataValueField = "Id";
            DropDownListProvincia.DataBind();
            DropDownListProvincia.Items.Insert(0, new ListItem("Seleccione Provincia", ""));
        }



        protected void btnMediosDePago_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CheckOut.aspx");
        }

        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEnvio.Checked)
            {
                DatosDestinatario.Visible = true;
                DatosFacturacion.Visible = false;
            }
            else if (rbRetiro.Checked)
            {
                DatosFacturacion.Visible = true;
                DatosDestinatario.Visible = false;
            }
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            int codogpPostal;

            if (int.TryParse(txtCodigoPostal.Text, out codogpPostal))
            {
                bool esValido = provinciaNegocio.ValidarCodigoPostal(codogpPostal);

                if (esValido)
                {
                    lblCPValidacion.Text ="Codigo Postal Valido";
                    lblCPValidacion.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblCPValidacion.Text = "Codigo Postal Invalido ";
                    lblCPValidacion.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lblCPValidacion.Text = "El Código Postal es invalido";
                lblCPValidacion.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void DropDownListProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (int.TryParse(DropDownListProvincia.SelectedValue, out int provinciaId))
            //{
            //    int codigoPostal;


            //    if (int.TryParse(txtCodigoPostal.Text, out codigoPostal))
            //    {

            //        bool esValido = provinciaNegocio.ValidarCodigoPostalPorProvincia(codigoPostal, provinciaId);

            //        if (esValido)
            //        {
            //            lblCPValidacion.Text = "Código Postal válido para la provincia seleccionada.";
            //            lblCPValidacion.ForeColor = System.Drawing.Color.Green;
            //        }
            //        else
            //        {
            //            lblCPValidacion.Text = "El Código Postal no corresponde a la provincia seleccionada.";
            //            lblCPValidacion.ForeColor = System.Drawing.Color.Red;
            //        }
            //    }
            //    else
            //    {
            //        lblCPValidacion.Text = "El Código Postal ingresado es inválido.";
            //        lblCPValidacion.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
            //else
            //{
            //    lblCPValidacion.Text = "Seleccione una provincia valida";
            //    lblCPValidacion.ForeColor = System.Drawing.Color.Red;
            //}
            // Verificar si la provincia está seleccionada correctamente
            if (int.TryParse(DropDownListProvincia.SelectedValue, out int provinciaId))
            {
                // Verificar si el Código Postal es un número válido
                if (int.TryParse(txtCodigoPostal.Text, out int codigoPostal))
                {
                    // Validar si el Código Postal corresponde a la provincia seleccionada
                    bool esValido = provinciaNegocio.ValidarCodigoPostalPorProvincia(codigoPostal, provinciaId);

                    // Mensajes de validación
                    if (esValido)
                    {
                        lblCPValidacion.Text = "Código Postal válido para la provincia seleccionada.";
                        lblCPValidacion.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblCPValidacion.Text = "El Código Postal no corresponde a la provincia seleccionada.";
                        lblCPValidacion.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblCPValidacion.Text = "El Código Postal ingresado es inválido.";
                    lblCPValidacion.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblCPValidacion.Text = "Seleccione una provincia válida.";
                lblCPValidacion.ForeColor = System.Drawing.Color.Red;
            }

            // Para depurar, podrías agregar estos registros para verificar el flujo:
            System.Diagnostics.Debug.WriteLine($"Provincia seleccionada ID: {DropDownListProvincia.SelectedValue}");
            System.Diagnostics.Debug.WriteLine($"Código Postal ingresado: {txtCodigoPostal.Text}");
        }
    }
}