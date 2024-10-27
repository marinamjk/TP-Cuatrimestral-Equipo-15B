using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        public int IdMarca { get; set; }
        [DisplayName("Descripción")]
        public string Nombre { get; set; }

        public bool Estado { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
