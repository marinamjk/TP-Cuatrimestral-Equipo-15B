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
                datos.setearParametros("@idCatPadre", idPadre.HasValue ? (object)idPadre.Value : DBNull.Value); 
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["IDCategoria"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.IDCategoriaPadre = datos.Lector["IDCategoriaPadre"] as int?;
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

        public List<Categoria> listarUltimasSubcategorias()
        {
            List<Categoria> listaSubcategorias = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ListarUltimasSubcategorias");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["IDCategoria"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.IDCategoriaPadre = datos.Lector["IDCategoriaPadre"] as int?;
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

        public void agregarCategoria(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarCategoria");
                datos.setearParametros("@Nombre", categoria.Nombre);
                datos.setearParametros("@IDCategoriaPadre", categoria.IDCategoriaPadre);
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


        public Categoria buscarCategoriaXId(int? IdCategoria)
        {
            Categoria aux = new Categoria(); ;
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Nombre, IDCategoriaPadre from Categorias where IDCategoria=" + IdCategoria);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    aux.IdCategoria = IdCategoria;
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["IDCategoriaPadre"] is DBNull))
                        aux.IDCategoriaPadre = (int)datos.Lector["IDCategoriaPadre"];
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

        public void modificarCategoria(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {                
                datos.setearProcedimiento("sp_ModificarCategoria");
                datos.setearParametros("@IDCategoria", categoria.IdCategoria);
                datos.setearParametros("@IDCategoriaPadre", categoria.IDCategoriaPadre);
                datos.setearParametros("@Nombre", categoria.Nombre);
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

        public void eliminarCategoria(int idCat)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_EliminarCategoria");
                datos.setearParametros("@IDCategoria", idCat);
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
