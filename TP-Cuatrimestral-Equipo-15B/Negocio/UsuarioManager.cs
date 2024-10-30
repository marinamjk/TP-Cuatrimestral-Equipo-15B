using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dominio;
using AccesoADatos;

namespace Negocio
{
    public class UsuarioManager
    {
        public List<Usuario> listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            return usuarios;
        }

        public void agregarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try {
                int id;
                datos.setearConsulta("INSERT INTO Usuarios(Nombre,Apellido,DNI,Email,Contrasenia,Telefono,IDTipoUsuario) values (@Nombre,@apellido,@DNI,@Email,@Contrasenia,'1169821424',1)");
                datos.setearParametros("@Nombre",usuario.Nombre);
                datos.setearParametros("@apellido",usuario.Apellido);
                datos.setearParametros("@DNI", usuario.Dni);
                datos.setearParametros("@Email",usuario.Mail);
                datos.setearParametros("@Contrasenia", usuario.Contraseña);
                datos.ejecutarEscalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario iniciar_sesion(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdUsuario, Nombre, Apellido, Email, Contrasenia FROM Usuarios where @email = Email");
                datos.setearParametros("@email", usuario.Mail);
                datos.ejecutarLectura();
                Usuario aux = new Usuario();
                while (datos.Lector.Read())
                {   
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Mail = (string)datos.Lector["Email"];
                    aux.Contraseña = (string)datos.Lector["Contrasenia"];
                }
                if((aux.Mail == usuario.Mail && aux.Contraseña == usuario.Contraseña))
                {
                    return aux;
                }
                return null;
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
