﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using AccesoADatos;

namespace Negocio
{
    public class UsuarioManager
    {
        public List<Usuario> listarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ListarUsuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IDUsuario"];
                    aux.Mail = (string)datos.Lector["Email"];
                    aux.Contraseña = (string)datos.Lector["Contrasenia"];
                    if (!(datos.Lector["IDDatosPersonales"] is DBNull))
                    {                        
                        buscarDatosPersonales(aux);
                    }

                    if (!(datos.Lector["IDDireccion"] is DBNull))
                        buscarDireccion(aux);

                    aux.Estado = (bool)datos.Lector["Estado"];
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return usuarios;
        }

        public int agregarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try {            
                datos.setearProcedimiento("sp_AgregarUsuario");
                datos.setearParametros("@Email", usuario.Mail);             
                datos.setearParametros("@Contrasenia", usuario.Contraseña);
                return datos.ejecutarEscalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //public Usuario iniciar_sesion(Usuario usuario)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setearConsulta("SELECT IdUsuario, Nombre, Apellido, Email, Contrasenia FROM Usuarios where @email = Email");
        //        datos.setearParametros("@email", usuario.Mail);
        //        datos.ejecutarLectura();
        //        Usuario aux = new Usuario();
        //        while (datos.Lector.Read())
        //        {   
        //            aux.IdUsuario = (int)datos.Lector["IdUsuario"];
        //            aux.Nombre = (string)datos.Lector["Nombre"];
        //            aux.Apellido = (string)datos.Lector["Apellido"];
        //            aux.Mail = (string)datos.Lector["Email"];
        //            aux.Contraseña = (string)datos.Lector["Contrasenia"];
        //        }
        //        if((aux.Mail == usuario.Mail && aux.Contraseña == usuario.Contraseña))
        //        {
        //            return aux;
        //        }
        //        return null;
                
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}

        public bool loguear(Usuario usuario)
        {
            AccesoDatos datos= new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_InciarSesion");
                datos.setearParametros("@Email", usuario.Mail);
                datos.setearParametros("@Contrasenia", usuario.Contraseña);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.IdUsuario = (int)(datos.Lector["IDUsuario"]);
                    usuario.Mail = (string)datos.Lector["Email"];
                    usuario.Contraseña = (string)datos.Lector["Contrasenia"];
                    usuario.tipoUsuario = (int)datos.Lector["IDTipoUsuario"] == 2 ? tipoUsuario.NORMAL : tipoUsuario.ADMIN;
                    
                    if (!(datos.Lector["IDDatosPersonales"] is DBNull))
                    {
                        buscarDatosPersonales(usuario);
                    }

                    if (!(datos.Lector["IDDireccion"] is DBNull))
                    {
                        buscarDireccion(usuario);
                    }

                    usuario.Estado = (bool)datos.Lector["Estado"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregarDatosPersonales(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarDatosPersonales");
                datos.setearParametros("@IDUsuario", usuario.IdUsuario);
                datos.setearParametros("@Nombre", usuario.Nombre);
                datos.setearParametros("@Apellido", usuario.Apellido);
                datos.setearParametros("@DNI", usuario.Dni);
                datos.setearParametros("@Telefono", usuario.telefono);
                datos.setearParametros("@UrlFotoPerfil", usuario.Foto);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void buscarDatosPersonales(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_BuscarDatosPersonales");
                datos.setearParametros("@IDUsuario", usuario.IdUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {                  
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.Dni = (string)datos.Lector["DNI"];
                    if (!(datos.Lector["Telefono"] is DBNull))
                    usuario.telefono = (string)datos.Lector["Telefono"];
                    if (!(datos.Lector["UrlFotoPerfil"] is DBNull))
                        usuario.Foto = (string)datos.Lector["UrlFotoPerfil"];
                }     

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarDatosPersonales(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ModificarDatosPersonales");   
                
                datos.setearParametros("@IDUsuario", usuario.IdUsuario);
                datos.setearParametros("@Nombre", usuario.Nombre);
                datos.setearParametros("@Apellido", usuario.Apellido);
                datos.setearParametros("@DNI", usuario.Dni);
                datos.setearParametros("@Telefono", usuario.telefono);
                datos.setearParametros("@UrlFotoPerfil", usuario.Foto);

                datos.ejecutarAccion();
       

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarDireccion(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarDireccion");
                datos.setearParametros("@IDUsuario", usuario.IdUsuario);
                datos.setearParametros("@Calle", usuario.Direccion.Calle);
                datos.setearParametros("@Numero", usuario.Direccion.Numero);
                datos.setearParametros("@IdProvincia", usuario.Direccion.IdProvincia);
                datos.setearParametros("@IdLocalidad", usuario.Direccion.IdLocalidad);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void buscarDireccion(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_BuscarDireccion");
                datos.setearParametros("@IDUsuario", usuario.IdUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {  
                    Direccion direccion= new Direccion();
                    direccion.Calle = (string)datos.Lector["Calle"];
                    direccion.Numero = (int)datos.Lector["Numero"];

                    usuario.Direccion.IdProvincia = (byte)datos.Lector["IdProvincia"];
                    Provincia provincia= new Provincia();
                    provincia.Id = (byte)datos.Lector["IdProvincia"];                    
                    provincia.Nombre = (string)datos.Lector["NombreProvincia"];
                    provincia.Codigo31662 = (string)datos.Lector["Codigo31662"];
                    direccion.Provincia = provincia;

                    usuario.Direccion.IdLocalidad = (int)datos.Lector["IdLocalidad"];
                    Localidad localidad = new Localidad();
                    localidad.Id= (byte)datos.Lector["IdLocalidad"];                    
                    localidad.Nombre = (string)datos.Lector["NombreLocalidad"];
                    localidad.CodigoPostal = (int)datos.Lector["CodigoPostal"];
                    localidad.ProvinciaId = (int)datos.Lector["ProvinciaId"];
                    direccion.Localidad = localidad;

                    usuario.Direccion = direccion;
              
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarDireccion(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ModificarDireccion");
                datos.setearParametros("@IDUsuario", usuario.IdUsuario);
                datos.setearParametros("@Calle", usuario.Direccion.Calle);
                datos.setearParametros("@Numero", usuario.Direccion.Numero);
                datos.setearParametros("@IdProvincia", usuario.Direccion.IdProvincia);
                datos.setearParametros("@IdLocalidad", usuario.Direccion.IdLocalidad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
