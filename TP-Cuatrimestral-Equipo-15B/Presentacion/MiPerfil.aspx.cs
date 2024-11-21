using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;
using static System.Net.WebRequestMethods;

namespace Presentacion
{
    
    public partial class MiPerfil : System.Web.UI.Page
	{
        public string titulo;
        public bool ModificarDireccion;
        public bool ModificarDatos;
        ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                CargarProvincias();
                if (Seguridad.sesionActiva(Session["usuario"]))
                {

                    Usuario us = (Usuario)Session["usuario"];
                    UsuarioManager um= new UsuarioManager();
                    if (um.buscarDatosPersonales(us))
                    {
                        titulo = us.Nombre;
                        TbNombre.Text = us.Nombre;
                        TbApellido.Text = us.Apellido;
                        TbDocumento.Text = us.Dni;
                        TbTelefono.Text = us.telefono;
                    }
                    if (um.buscarDireccion(us))
                    {
                        txtCalle.Text = us.Direccion.Calle;
                        txtCalle.Text = us.Direccion.Calle;
                        txtCodigoPostal.Text = us.Direccion.Localidad.CodigoPostal.ToString();
                        txtNumero.Text = us.Direccion.Numero.ToString();
                        txtLocalidad.Text = us.Direccion.Localidad.Nombre;
                        DropDownListProvincia.SelectedValue = us.Direccion.Provincia.Id.ToString();
                    }
                    
                }

                TbNombre.Enabled = false;
                TbApellido.Enabled = false;
                TbDocumento.Enabled = false;
                TbTelefono.Enabled = false;
                txtCalle.Enabled = false;
                txtCodigoPostal.Enabled = false;
                txtLocalidad.Enabled = false;
                txtNumero.Enabled = false;

                ModificarDireccion = false;
                ModificarDatos = false;
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
        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            int codogpPostal;
          
            if (int.TryParse(txtCodigoPostal.Text, out codogpPostal))
            {
                bool esValido = provinciaNegocio.ValidarCodigoPostal(codogpPostal);

                if (esValido)
                {
                    lblCPValidacion.Text = "Codigo Postal Valido";
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
                if (int.TryParse(txtCodigoPostal.Text, out int codigoPostal))
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
                       

        protected void BtGuardarDireccion_Click(object sender, EventArgs e)
        {
            Usuario usuario = ((Usuario)Session["usuario"]);
            UsuarioManager Usuarios = new UsuarioManager();

            Direccion direccion = new Direccion();
            direccion.Calle = txtCalle.Text;
            direccion.Numero = int.Parse(txtNumero.Text);
            ProvinciaNegocio pn = new ProvinciaNegocio();
            Provincia p = new Provincia();
            p.Id = byte.Parse(DropDownListProvincia.SelectedValue);
            direccion.IdProvincia = p.Id;
            Localidad l = new Localidad();
            l.CodigoPostal = int.Parse(txtCodigoPostal.Text);
            l.Id = pn.obtenerIdLocalidadPorCP(l.CodigoPostal);
            direccion.IdLocalidad = l.Id;

            if (Usuarios.verificarDireccion(usuario.IdUsuario))
            {
                Usuarios.ModificarDireccion(direccion, usuario.IdUsuario);
            }
            else
            {
                Usuarios.agregarDireccion(direccion, usuario.IdUsuario);
            }
            string script = "document.getElementById('fieldsetDireccion').disabled = false;";
            ScriptManager.RegisterStartupScript(this, GetType(), "DisableFieldset", script, true);

            Session["usuario"] = usuario;
            Response.Redirect("MiPerfil.aspx", false);
        }

         protected void BtModificarDireccion_Click(object sender, EventArgs e)
        {
            txtCalle.Enabled = true;
            txtCodigoPostal.Enabled = true;
            txtLocalidad.Enabled = true;
            txtNumero.Enabled = true;
            string script = "document.getElementById('fieldsetDireccion').disabled = false;";
            ScriptManager.RegisterStartupScript(this, GetType(), "DisableFieldset", script, true);
            ModificarDireccion = true;
        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            TbNombre.Enabled = true;
            TbApellido.Enabled = true;
            TbDocumento.Enabled = true;
            TbTelefono.Enabled = true;
            string script = "document.getElementById('fieldsetDatos').disabled = false;";
            ScriptManager.RegisterStartupScript(this, GetType(), "DisableFieldset", script, true);
            ModificarDatos = true;
        }

        protected void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            Usuario usuario = ((Usuario)Session["usuario"]);
            UsuarioManager Usuarios = new UsuarioManager();

            usuario.Nombre = TbNombre.Text;
            usuario.Apellido = TbApellido.Text;
            usuario.Dni = TbDocumento.Text;
            usuario.telefono = TbTelefono.Text;
            usuario.Foto = "https://imgs.search.brave.com/-BtlJWfCZK6-fD12f_E5yeLNpr21GR9F3GZBvDPuKdY/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZW5lc2Jvbml0YXMu/Ym9zcXVlZGVmYW50/YXNpYXMuY29tL3dw/LWNvbnRlbnQvdXBs/b2Fkcy8yMDE1LzA5/L2ZvdG9zLWRlLWdv/a3UtNDAweDI4NC5q/cGc";


            if (!Usuarios.verificarDatosPersonales(usuario.IdUsuario))
            {
                Usuarios.agregarDatosPersonales(usuario);
            }
            else
            {
                Usuarios.ModificarDatosPersonales(usuario);
            }

            Session["usuario"] = usuario;
            Response.Redirect("MiPerfil.aspx", false);
        }
    }
}