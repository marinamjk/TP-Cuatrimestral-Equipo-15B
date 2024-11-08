using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoADatos;

namespace Negocio
{
    public class ColeccionNegocio
    {
               
        public List<Coleccion> listarColecciones()
        {
            List<Coleccion> listaColecciones = new List<Coleccion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_listarColecciones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Coleccion aux= new Coleccion();
                    aux.IdColeccion = (int)datos.Lector["IDColeccion"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    listaColecciones.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            { 
                datos.cerrarConexion();
            }

            return listaColecciones;
        }

        public void agregarColeccion(Coleccion coleccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarColeccion");
                datos.setearParametros("@Nombre", coleccion.Nombre);
                datos.ejecutarAccion(); 

            } catch (Exception ex) {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarColeccion(Coleccion coleccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ModificarColeccion");
                datos.setearParametros("@IDColeccion", coleccion.IdColeccion);          
                datos.setearParametros("@Nombre", coleccion.Nombre);
                datos.ejecutarAccion();
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

        public void eliminarColeccionLogicamente(int idColeccion, bool estado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_EliminarColeccionLogicamente");
                datos.setearParametros("@IDColeccion", idColeccion);
                datos.setearParametros("@Estado", estado);
                datos.ejecutarAccion();
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
    }
}
