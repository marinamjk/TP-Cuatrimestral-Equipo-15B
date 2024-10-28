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

                   
                    aux.Marca= new Marca();
                    if (!(datos.Lector["IDMarca"] is DBNull))
                        aux.Marca.IdMarca = (int)datos.Lector["IDMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["NombreMarca"];

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
                datos.setearConsulta("Select A.Nombre, A.Descripcion, A.IDMarca, M.Nombre as 'NombreMarca', A.IDCategoria, C.Nombre as 'NombreMarca', A.Precio, A.Stock, A.Puntaje, A.Estado from Articulos A Inner Join Marcas M on M.IDMarca= A.IDMarca inner join Categorias C on C.IDCategoria= A.IDCategoria where IDArticulo =" + id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    aux.IdArticulo = id;
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];


                    aux.Marca = new Marca();
                    if (!(datos.Lector["IDMarca"] is DBNull))
                        aux.Marca.IdMarca = (int)datos.Lector["IDMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["NombreMarca"];

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
                datos.setearParametros("IDMarca", nuevo.Marca.IdMarca);
                datos.setearParametros("IDCategoria", nuevo.Categoria.IdCategoria);
                datos.setearParametros("Precio", nuevo.Precio);
                datos.setearParametros("Stock", nuevo.Stock);
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
    }
}
