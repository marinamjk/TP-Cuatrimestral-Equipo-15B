using AccesoADatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> buscarImagenesXArticulo(int IdArticulo)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select IDImagen, IdArticulo, UrlImagen from Imagenes where IDArticulo= @IDArticulo");
                datos.setearParametros("@IDArticulo", IdArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.IdImagen = (int)datos.Lector["IDImagen"];
                    aux.IdArticulo = IdArticulo;
                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    imagenes.Add(aux);
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
            return imagenes;
        }

        public void agregarImagen(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarImagen");
                datos.setearParametros("@IDArticulo", imagen.IdArticulo);
                datos.setearParametros("@Url", imagen.UrlImagen );    
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

        public void eliminarImagenesXIDArticulo(int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_EliminarImagenesXArticulo");
                datos.setearParametros("@IDArticulo", IdArticulo);              
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
