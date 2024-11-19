using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum tipoUsuario
    {
        NORMAL = 2,
        ADMIN = 1
    }
    public class Usuario
    {
        public Usuario()
        {
            modificar = false;
        }
        public int IdUsuario { get; set; }
        public int? IdDatosPersonales { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string telefono { get; set; }
        public string Mail { get; set; }
        public string Contraseña { get; set; }
        public tipoUsuario tipoUsuario{ get; set; }
        public Direccion Direccion { get; set; }
        public string Foto {  get; set; }       
        public bool modificar {  get; set; }
        public bool Estado { get; set; }
        public bool esAdministrador()
        {
            return tipoUsuario== tipoUsuario.ADMIN? true : false;
        }
              
    }
}
