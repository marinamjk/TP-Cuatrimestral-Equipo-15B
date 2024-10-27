using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoADatos;

namespace Negocio
{
    public class MarcaNegocio
    {
               
        public List<Marca> listarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_listarMarcas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux= new Marca();
                    aux.IdMarca = (int)datos.Lector["IDMarca"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Estado = (bool)datos.Lector["Estado"];
                    listaMarcas.Add(aux);
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

            return listaMarcas;
        }
    }
}
