using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pedido
    {
        //datos propios del pedido
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public string TipoEntrega { get; set; }
        public DateTime FechaPedido { get; set; }

        public int IdMetodoPago { get; set; }
        public MetodoPago MetodoPago {  get; set; }
        public int EstadoPedido { get; set; }   
        public decimal Total {  get; set; }
        //datos que pueden ser de usuario o persona u otro tipo de clase
     //   public string NombreCliente {  get; set; }  
	    //public string ApellidoCliente {  get; set; }
     //   public string DNI { get; set; }
	    //public string Email {  get; set; }
     //   public string Telefono {  get; set; }
     //   //datos que tambien pueden ser heredados de direccion 
	    //public string Calle {  get; set; }
     //   public string Numero {  get; set; }
     //   public string CodigoPostal {  get; set; }
     //   public string Provincia {  get; set; }
    }
}
