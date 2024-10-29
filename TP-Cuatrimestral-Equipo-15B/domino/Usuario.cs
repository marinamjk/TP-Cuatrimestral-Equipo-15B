using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum tipoUsuario
    {
        Comprador = 2,
        Vendedor = 1,
    }
    public class Usuario
    {
        public int IdUsuario {  get; set; }
        public string Nombre {  get; set; }
        public string Apellido {  get; set; }
        public string Dni {  get; set; }
        public string Mail { get; set; }
        public string Contraseña {  get; set; }
        public string telefono {  get; set; }
        public int IdDireccion {  get; set; }
        public int IdTarjeta {  get; set; }
        public string Foto {  get; set; }
    }
}
