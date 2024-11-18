﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoADatos;
using System.Data.SqlClient;
using System.Net;
using System.Collections;

namespace Negocio
{
    public class PedidoNegocio
    {
        //public int GuardarPedido(Pedido pedido)
        //{
        //    AccesoDatos accesoDatos = new AccesoDatos();
        //    int idPedido;
        //    try
        //    {
        //        if (pedido.FechaPedido < new DateTime(1753, 1, 1))
        //        {
        //            pedido.FechaPedido = DateTime.Now;
        //        }


        //        accesoDatos.setearConsulta("INSERT INTO Pedido (FechaPedido, NombreCliente, ApellidoCliente, Email, Telefono, Calle, Numero, CodigoPostal, Provincia, DNI, IdMetodoPago, Total, TipoEntrega) " +
        //               "OUTPUT INSERTED.IdPedido " +
        //               "VALUES (@FechaPedido, @NombreCliente, @ApellidoCliente, @Email, @Telefono, @Calle, @Numero, @CodigoPostal, @Provincia, @DNI, @IdMetodoPago, @Total, @TipoEntrega)");


        //        accesoDatos.setearParametros("@FechaPedido", pedido.FechaPedido);
        //        accesoDatos.setearParametros("@TipoEntrega", pedido.TipoEntrega);
        //        accesoDatos.setearParametros("@NombreCliente", pedido.NombreCliente);
        //        accesoDatos.setearParametros("@ApellidoCliente", pedido.ApellidoCliente);
        //        accesoDatos.setearParametros("@Email", pedido.Email);
        //        accesoDatos.setearParametros("@Telefono", pedido.Telefono);
        //        accesoDatos.setearParametros("@DNI", pedido.DNI);
        //        accesoDatos.setearParametros("@IdMetodoPago", pedido.IdMetodoPago);
        //        accesoDatos.setearParametros("@Total", pedido.Total);

        //        if (pedido.TipoEntrega == "Retiro")
        //        {
        //            // Si es retiro, los campos de dirección serán nulos
        //            accesoDatos.setearParametros("@Calle", DBNull.Value);
        //            accesoDatos.setearParametros("@Numero", DBNull.Value);
        //            accesoDatos.setearParametros("@CodigoPostal", DBNull.Value);
        //            accesoDatos.setearParametros("@Provincia", DBNull.Value);
        //        }
        //        else
        //        {
        //            // Si es envío, se asignan los valores correspondientes
        //            accesoDatos.setearParametros("@Calle", pedido.Calle);
        //            accesoDatos.setearParametros("@Numero", pedido.Numero);
        //            accesoDatos.setearParametros("@CodigoPostal", pedido.CodigoPostal);
        //            accesoDatos.setearParametros("@Provincia", pedido.Provincia);
        //        }

        //        idPedido = accesoDatos.ejecutarEscalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al guardar el pedido: " + ex.Message, ex);
        //    }
        //    finally
        //    {
        //        accesoDatos.cerrarConexion();
        //    }
        //    return idPedido;

        //}

        public int agregarPedido(Pedido pedido, int idUsuario)
        {
           AccesoDatos datos= new AccesoDatos();
         
            try
            {
                datos.setearProcedimiento("sp_AgregarPedido");
                datos.setearParametros("@IDUsuario", idUsuario);
                datos.setearParametros("@TipoEntrega", pedido.TipoEntrega);
                datos.setearParametros("@IdMetodoPago", pedido.IdMetodoPago);
                datos.setearParametros("@Total", pedido.Total);
                
                return datos.ejecutarEscalar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
     

        public void GuardarDetallesPedido(int idPedido, List<ArticuloEnCarrito> articulos)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                foreach (ArticuloEnCarrito articuloCarrito in articulos)
                {
                    accesoDatos.setearConsulta("INSERT INTO PedidoDetalle (IdPedido, IdArticulo, Cantidad, PrecioUnitario) VALUES (@idPedido, @idArticulo, @cantidad, @precioUnitario)");
                    accesoDatos.setearParametros("@idPedido", idPedido);
                    accesoDatos.setearParametros("@idArticulo", articuloCarrito.Articulo.IdArticulo);
                    accesoDatos.setearParametros("@cantidad", articuloCarrito.Cantidad);
                    accesoDatos.setearParametros("@precioUnitario", articuloCarrito.Articulo.Precio);
                    accesoDatos.ejecutarAccion();
                    accesoDatos.limpiarParametros();
                    accesoDatos.cerrarConexion();

                    // Actualizamos el stock del artículo
                    accesoDatos.setearConsulta("UPDATE Articulos SET Stock = Stock - @cantidad WHERE IDArticulo = @idArticulo");
                    accesoDatos.setearParametros("@cantidad", articuloCarrito.Cantidad);
                    accesoDatos.setearParametros("@idArticulo", articuloCarrito.Articulo.IdArticulo);
                    accesoDatos.ejecutarAccion();
                    accesoDatos.limpiarParametros();
                    accesoDatos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar los detalles del pedido: " + ex.Message);
            }
           
        }

    }
}
