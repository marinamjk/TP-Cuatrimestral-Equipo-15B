﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class MetodoPago
    {
        public int IdMetodoPago {  get; set; }  
        public string Nombre { get; set; }
        public string Descrípcion { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
