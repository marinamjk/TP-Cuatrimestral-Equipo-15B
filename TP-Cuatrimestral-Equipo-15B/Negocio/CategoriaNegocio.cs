using AccesoADatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_listarCategorias");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["IDCategoria"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["IDCategoriaPadre"] is DBNull))
                        aux.IDCategoriaPadre = (int)datos.Lector["IDCategoriaPadre"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    listaCategorias.Add(aux);
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

            return listaCategorias;
        }
        public List<Categoria> listarSubcategorias(int? idPadre)
        {
            List<Categoria> listaSubcategorias = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_listarSubcategorias");
                datos.setearParametros("@idCatPadre", idPadre.HasValue ? (object)idPadre.Value : DBNull.Value);                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["IDCategoria"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.IDCategoriaPadre = datos.Lector["IDCategoriaPadre"] as int?;
                    aux.Estado = (bool)datos.Lector["Estado"];
                    listaSubcategorias.Add(aux);
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

            return listaSubcategorias;
        }
        public Categoria buscarCategoriaXId(int? IdCategoria)
        {
            Categoria aux = new Categoria(); ;
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Nombre, IDCategoriaPadre, Estado from Categorias where IDCategoria=" + IdCategoria);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    aux.IdCategoria = IdCategoria;
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["IDCategoriaPadre"] is DBNull))
                        aux.IDCategoriaPadre = (int)datos.Lector["IDCategoriaPadre"];
                    aux.Estado = (bool)datos.Lector["Estado"];
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

       
    }
}
