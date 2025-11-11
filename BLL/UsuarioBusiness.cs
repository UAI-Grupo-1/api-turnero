using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBusiness
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        // Obtener usuario por nombre de usuario
        public Usuario GetUserByName(string name)
        {
            return usuarioDAL.GetUsuarioByUsername(name);
        }

        // Validar credenciales de usuario
        public bool ValidarCredenciales(string username, string password)
        {
            Usuario usuario = GetUserByName(username);
            if (usuario != null && usuario.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}