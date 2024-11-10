using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(Object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.IdUsuario != 0)
                return true;
            else
                return false;
        }

        public static bool esAdministrador (Object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.esAdministrador())
                return true;
            else
                return false;
        }
    }
}
