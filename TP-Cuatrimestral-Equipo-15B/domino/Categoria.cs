﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public int? IDCategoriaPadre { get; set; }
        public bool Estado { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
