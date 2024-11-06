using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoADatos;

namespace Negocio
{
    public class MarcaNegocio
    {
               
        public List<Marca> listarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_listarMarcas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux= new Marca();
                    aux.IdMarca = (int)datos.Lector["IDMarca"];
                    aux.Nombre = (string)datos.Lector["Nombre"];            
                    listaMarcas.Add(aux);
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

            return listaMarcas;
        }

        public void agregarMarca(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarMarca");
                datos.setearParametros("@Nombre", marca.Nombre);
                datos.ejecutarAccion(); 

            } catch (Exception ex) {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarMarca(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ModificarMarca");
                datos.setearParametros("@IDMarca", marca.IdMarca);          
                datos.setearParametros("@Nombre", marca.Nombre);
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

        public void eliminarMarca(int idMarca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_EliminarMarca");
                datos.setearParametros("@IDMarca", idMarca);
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
