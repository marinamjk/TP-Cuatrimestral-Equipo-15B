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
            if (!rbEnvio.Checked && !rbRetiro.Checked)
            {
                lblAdvertencia.Text = "Seleccione Envio o Retiro";
                lblAdvertencia.Visible = true;
            }
            else if (rbEnvio.Checked)
            {
                lblAdvertencia.Visible = false;

                if (string.IsNullOrWhiteSpace(TextEmail.Text) || string.IsNullOrWhiteSpace(TextNombre.Text) ||
                    string.IsNullOrWhiteSpace(TextApellido.Text) || string.IsNullOrWhiteSpace(TextTelefono.Text) ||
                    string.IsNullOrWhiteSpace(TextCalle.Text) || string.IsNullOrWhiteSpace(TextNumero.Text) ||
                    string.IsNullOrWhiteSpace(TextCodigoPostal.Text)||string.IsNullOrWhiteSpace(TextDNI.Text))
                {
                    lblAdvertencia.Text = "Complete los datos de Contacto";
                    lblAdvertencia.Visible = true;
                }
                else
                {                   
                    Session["NombreCliente"] = TextNombre.Text;
                    Session["ApellidoCliente"] = TextApellido.Text;
                    Session["Email"] = TextEmail.Text;
                    Session["Telefono"] = TextTelefono.Text;
                    Session["Calle"] = TextCalle.Text;
                    Session["Numero"] = TextNumero.Text;
                    Session["CodigoPostal"] = TextCodigoPostal.Text;
                    Session["Provincia"] = DropDownListProvincia.SelectedItem.Text;
                    Session["DNI"] = TextDNI.Text;

                    Response.Redirect("~/MetodosPago.aspx");
                }
            }
            else if (rbRetiro.Checked)
            {
                lblAdvertencia.Visible = false;

                if ((string.IsNullOrWhiteSpace(TextEmail.Text) || string.IsNullOrWhiteSpace(TextNombre.Text) ||
                    string.IsNullOrWhiteSpace(TextApellido.Text) || string.IsNullOrWhiteSpace(TextTelefono.Text) || 
                    string.IsNullOrWhiteSpace(TextDNI.Text)))                   
                {
                    lblAdvertencia.Text = "Complete los datos de Contacto";
                    lblAdvertencia.Visible = true;
                }
                else
                {
                    Session["NombreCliente"] = TextNombre.Text;
                    Session["ApellidoCliente"] = TextApellido.Text;
                    Session["Email"] = TextEmail.Text;
                    Session["Telefono"] = TextTelefono.Text;
                    Session["DNI"] = TextDNI.Text;
                                       
                    Response.Redirect("~/MetodosPago.aspx");
                }
            }
        }


        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEnvio.Checked)
            {
                DatosDestinatario.Visible = true;
                DatosFacturacion.Visible = true;
                DireccionContacto.Visible = true;
                Session["TipoEntrega"] = "Envio";
            }
            else if (rbRetiro.Checked)
            {
                DatosDestinatario.Visible = true;
                DatosFacturacion.Visible = true;
                DireccionContacto.Visible = false;
                Session["TipoEntrega"] = "Retiro";
            }
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            int codogpPostal;

            if (int.TryParse(TextCodigoPostal.Text, out codogpPostal))
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
            // si la provincia esta seleccionada correctamente
            if (int.TryParse(DropDownListProvincia.SelectedValue, out int provinciaId))
            {
                // si el CP es un numero valido
                if (int.TryParse(TextCodigoPostal.Text, out int codigoPostal))
                {                   
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
        }
    }
}