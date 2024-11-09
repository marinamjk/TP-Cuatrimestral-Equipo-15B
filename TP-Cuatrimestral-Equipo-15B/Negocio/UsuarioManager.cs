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
        public List<Usuario> listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

            }
            catch (Exception)
            {

                throw;
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
                datos.setearConsulta("Select IDUsuario, IDTipoUsuario from Usuarios where Email=@Email and Contrasenia=@Contrasenia");
                datos.setearParametros("@Email", usuario.Mail);
                datos.setearParametros("@Contrasenia", usuario.Contraseña);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.IdUsuario = (int)(datos.Lector["IDUsuario"]);
                    usuario.tipoUsuario = (int)datos.Lector["IDTipoUsuario"] == 2 ? tipoUsuario.NORMAL : tipoUsuario.ADMIN;                    
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
    }
}
