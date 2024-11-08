using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoADatos;
using System.Collections;
using System.Security.Policy;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarConSP()
        {
            List<Articulo> catalogo = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_listarArticulos");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.IdArticulo = (int)datos.Lector["IDArticulo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                                       
                    aux.Coleccion= new Coleccion();
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
                
                    catalogo.Add(aux);
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

            return catalogo;
        }

        public Articulo buscarArticuloXId(int id)
        {
            Articulo aux= new Articulo();

            AccesoDatos datos= new AccesoDatos();
            try
            {
                datos.setearConsulta("Select A.Nombre, A.Descripcion, A.IDColeccion, CO.Nombre as 'NombreColeccion', A.IDCategoria, C.Nombre as 'NombreCategoria', A.Precio, A.Stock, A.Puntaje from Articulos A Inner Join Colecciones CO on CO.IDColeccion= A.IDColeccion inner join Categorias C on C.IDCategoria= A.IDCategoria where IDArticulo =" + id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    aux.IdArticulo = id;
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

                    ImagenNegocio im_negocio = new ImagenNegocio();
                    aux.Imagenes = im_negocio.buscarImagenesXArticulo(aux.IdArticulo);

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
            return aux;
        }

        public int agregarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarArticulo");
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@IDColeccion", nuevo.Coleccion.IdColeccion);
                datos.setearParametros("@IDCategoria", nuevo.Categoria.IdCategoria);
                datos.setearParametros("@Precio", nuevo.Precio);
                datos.setearParametros("@Stock", nuevo.Stock);
                return datos.ejecutarEscalar();
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

        public void modificarArticulo(Articulo art)
        {
            AccesoDatos datos= new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ModificarArticulo");
                datos.setearParametros("@IDArticulo", art.IdArticulo);
                datos.setearParametros("@Nombre", art.Nombre);     
                datos.setearParametros("@Descripcion", art.Descripcion);
                datos.setearParametros("@IDColeccion", art.Coleccion.IdColeccion);
                datos.setearParametros("@IDCategoria", art.Categoria.IdCategoria);
                datos.setearParametros("@Precio", art.Precio);
                datos.setearParametros("@Stock", art.Stock);
                datos.ejecutarAccion();  
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //public void eliminarArticuloFisicamente(int idArt)
        //{
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearProcedimiento("sp_EliminarArticuloFisicamente");
        //        datos.setearParametros("@IDArticulo", idArt);
        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        public void eliminarArticuloLogicamente(int idArt, bool activo= false)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_EliminarArticuloLogicamente");
                datos.setearParametros("@IDArticulo", idArt);
                datos.setearParametros("@Estado", activo);
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
