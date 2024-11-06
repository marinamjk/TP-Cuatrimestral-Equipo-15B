using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public class AgregadosNegocio
    {
        public void agregarPuntaje(int IDPedido, int IDArticulo, int puntuacion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarPuntaje");
                datos.setearParametros("@IDPedido", IDPedido);
                datos.setearParametros("@IDArticulo", IDArticulo);
                datos.setearParametros("@Puntuacion", puntuacion);
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

        public List<Articulo> listarFavoritos(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> Favoritos= new List<Articulo>();
            try
            {
                datos.setearProcedimiento("sp_ListarFavoritos");
                datos.setearParametros("@IDusuario", idUsuario);
                datos.ejecutarAccion();
                return Favoritos;
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

        public bool agregarAFavoritos(int IDUsuario, int IDArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_AgregarAFavoritos");
                datos.setearParametros("@IDUsuario", IDUsuario);
                datos.setearParametros("IDArticulo", IDArticulo);
                int result = datos.ejecutarEscalar();

                return result > 0;               
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

        public void eliminarDeFavoritos(int IDUsuario, int IDArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_EliminarDeFavoritos");
                datos.setearParametros("@IDUsuario", IDUsuario);
                datos.setearParametros("IDArticulo", IDArticulo);
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

        public void buscarFavorito()
        {

        }

    }
}
