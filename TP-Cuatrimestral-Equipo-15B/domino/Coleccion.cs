using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Coleccion
    {
        public int IdColeccion { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        public bool Estado { get; set; }
          
        public override string ToString()
        {
            return Nombre;
        }
    }
}
