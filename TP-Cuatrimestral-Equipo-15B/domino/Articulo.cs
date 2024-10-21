using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        //public Marca Marca { get; set; }
        //[DisplayName("Categoría")]
        public int IDMarca { get; set; }
        //public Categoria Categoria { get; set; }
        public int IDCategoria { get; set; }    
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public List<Imagen> Imagenes { get; set; }
    }
}
