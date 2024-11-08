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
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Colección")]
        public Coleccion Coleccion { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }    
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public decimal Puntaje { get; set; }
        public bool Estado {  get; set; }   
    }
}
