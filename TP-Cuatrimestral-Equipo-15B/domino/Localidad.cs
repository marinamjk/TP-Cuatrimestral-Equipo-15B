﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Localidad
    {
        int Id {  get; set; }  
        public string Nombre {  get; set; }
        public int CodigoPostal { get;set; }
        public int ProvinciaId { get; set; }

        public Provincia Provincia {  get; set; }

    }
}
