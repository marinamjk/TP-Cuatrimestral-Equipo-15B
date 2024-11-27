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
        public bool agregarCupon;
        protected void Page_Load(object sender, EventArgs e)
        {
            carritoNegocio = new CarritoNegocio();
            provinciaNegocio = new ProvinciaNegocio();

            if (!IsPostBack)
            {
                //// Inicializa los valores si es la primera carga               
                CargarResumenCompra();
                CargarProvincias();

                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    TextEmail.Text = ((Usuario)Session["usuario"]).Mail.ToString();
                    TextEmail.Enabled = false;
                }
            }
            agregarCupon = false;
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
                    Session["Provincia"] = DropDownListProvincia.SelectedValue;
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

            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                UsuarioManager um = new UsuarioManager();
                Usuario usuario = (Usuario)Session["usuario"];

                if (um.buscarDatosPersonales(usuario))
                {
                    TextNombre.Text = usuario.Nombre;
                    TextApellido.Text = usuario.Apellido;
                    TextEmail.Text = usuario.Mail;
                    TextTelefono.Text = usuario.telefono;
                    TextDNI.Text = usuario.Dni.ToString();

                    TextNombre.Enabled = false;
                    TextApellido.Enabled = false;
                    TextEmail.Enabled = false;
                    TextTelefono.Enabled = false;
                    TextDNI.Enabled = false;
                }
                if (um.buscarDireccion(usuario))
                {
                    TextCalle.Text = usuario.Direccion.Calle;
                    TextNumero.Text = usuario.Direccion.Numero.ToString();
                    TextCodigoPostal.Text = usuario.Direccion.Localidad.CodigoPostal.ToString();
                    TextLocalidad.Text = usuario.Direccion.Localidad.Nombre.ToString();
                    DropDownListProvincia.SelectedValue = usuario.Direccion.Provincia.Id.ToString();
                    
                    TextCalle.Enabled = false;
                    TextNumero.Enabled = false;
                    TextCodigoPostal.Enabled = false;
                    TextLocalidad.Enabled = false;
                    DropDownListProvincia.Enabled = false;

                }
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

        protected void TextEmail_TextChanged(object sender, EventArgs e)
        {
            UsuarioManager um = new UsuarioManager();
            var usuarioEncontrado = um.listarUsuarios().FirstOrDefault(c => c.Mail == TextEmail.Text);
            Usuario nuevo = new Usuario();
            if (!Seguridad.sesionActiva(Session["usuario"]))
            {            
                if (usuarioEncontrado!=null && usuarioEncontrado.Estado==true)
                {
                    Session.Add("error", "Ya existe un usuario con ese email, por favor inicie sesion para poder cargar sus datos");
                    Response.Redirect("Error.aspx", false);
                }              
                else if(usuarioEncontrado!=null && usuarioEncontrado.Estado==false)
                {
                    nuevo = usuarioEncontrado;
                    Session.Add("usuarioSinSesion", nuevo);
                }
                else
                {
                    nuevo.Mail = TextEmail.Text;
                    nuevo.Contraseña = GenerarContraseña(6);
                    nuevo.Estado = false;
                    nuevo.IdUsuario = um.agregarUsuario(nuevo);
                    Session.Add("usuarioSinSesion", nuevo);
                }
                
            } 
           
        }

        protected string GenerarContraseña(int longitud)
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] contraseña = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                contraseña[i] = caracteres[random.Next(caracteres.Length)];
            }

            return new string(contraseña);
        }

        protected void BtDescuento_Click(object sender, EventArgs e)
        {
            agregarCupon = true;
        }
    }
}