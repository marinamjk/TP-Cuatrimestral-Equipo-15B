using AccesoADatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class ImagenNegocio
    {
        public List<Imagen> buscarImagenesXArticulo(int IdArticulo)
        {
            List<Imagen> imagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select IdImagen, IdArticulo, UrlImagen from Imagenes where IDArticulo= @IDArticulo");
                datos.setearParametros("@IDArticulo", IdArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    if (!(datos.Lector["IdImagen"] is DBNull))
                        aux.IdImagen = (int)datos.Lector["IdImagen"];
                    if (!(datos.Lector["IdArticulo"] is DBNull))
                        aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
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
    }
}
