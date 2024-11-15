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
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.IdArticulo = (int)datos.Lector["IDArticulo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Coleccion = new Coleccion();
                    if (!(datos.Lector["IDColeccion"] is DBNull))
                        aux.Coleccion.IdColeccion = (int)datos.Lector["IDColeccion"];
                    aux.Coleccion.Nombre = (string)datos.Lector["NombreColeccion"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IDCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["NombreCategoria"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    aux.Stock = (int)datos.Lector["Stock"];

                    if (!(datos.Lector["Puntaje"] is DBNull))
                        aux.Puntaje = (decimal)datos.Lector["Puntaje"];

                    aux.Estado = (bool)datos.Lector["Estado"];

                    ImagenNegocio im_negocio = new ImagenNegocio();

                    aux.Imagenes = im_negocio.buscarImagenesXArticulo(aux.IdArticulo);

                    Favoritos.Add(aux);
                }
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

        public void agregarAFavoritos(int IDUsuario, int IDArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_AgregarAFavoritos");
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


    }
}
