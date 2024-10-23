using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domino
{
    public enum tipoUsuario
    {
        usuario = 2,
        admin = 1,
    }
    public class Usuario
    {
        public int IdUsuario {  get; set; }
        public char Nombre {  get; set; }
        public char Apellido {  get; set; }
        public char Dni {  get; set; }
        public char Mail { get; set; }
        public char Contraseña {  get; set; }
        public char telefono {  get; set; }
        public int IdDireccion {  get; set; }
        public int IdTarjeta {  get; set; }
        public char Foto {  get; set; }
    }
}
