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
    }
}
