using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoADatos;
using dominio;

namespace Negocio
{
    public class ProvinciaNegocio
    {
       
        public List<Provincia> ObtenerProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Codigo31662 FROM Provincia");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Provincia provincia = new Provincia();

                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Id")))
                    {
                        provincia.Id = datos.Lector.GetByte(datos.Lector.GetOrdinal("Id"));
                    }
                    else
                    {
                        provincia.Id = 0;
                    }



                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Nombre")))
                    {
                        provincia.Nombre = (string)datos.Lector["Nombre"];
                    }
                    else
                    {
                        provincia.Nombre = string.Empty;  
                    }

                    
                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Codigo31662")))
                    {
                        provincia.Codigo31662 = (string)datos.Lector["Codigo31662"];
                    }
                    else
                    {
                        provincia.Codigo31662 = string.Empty;
                    }

                    provincias.Add(provincia);
                }
                return provincias;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
        public bool ValidarCodigoPostal(int codigoPostal)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Localidad WHERE CodigoPostal = @CodigoPostal");
                datos.setearParametros("@CodigoPostal", codigoPostal);
                return datos.ejecutarEscalar() > 0;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
		

    }
}
