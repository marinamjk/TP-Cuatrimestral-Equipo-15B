using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoADatos;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> catalogo = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select A.IDArticulo, A.Codigo, A.Nombre, A.Descripcion, A.IDMarca, A.IDCategoria, A.Precio, A.Stock from Articulos A");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.IdArticulo = (int)datos.Lector["IDArticulo"];

                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["IDMarca"] is DBNull))
                        aux.IDMarca = (int)datos.Lector["IDMarca"];

                    //aux.Categoria = new Categoria();
                    //if (!(datos.Lector["Categoria"] is DBNull))
                    //    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    //aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];

                    if (!(datos.Lector["IDCategoria"] is DBNull))
                        aux.IDMarca = (int)datos.Lector["IDCategoria"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["Stock"] is DBNull))
                        aux.Stock = (int)datos.Lector["Stock"];

                    ImagenNegocio im = new ImagenNegocio();
                    aux.Imagenes = im.buscarImagenesXArticulo(aux.IdArticulo);
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
    }
}
