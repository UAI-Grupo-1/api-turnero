using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class UsuarioMapper
    {
        public static Usuario Map(SqlDataReader reader, Usuario usuario)
        {
            // Mapear los datos del SqlDataReader a una instancia de Usuario
            usuario.IdUsuario = Convert.ToInt32(reader["id_usuario"]);
            usuario.Username = reader["username"].ToString();
            usuario.Password = reader["password"].ToString();
            usuario.Email = reader["email"].ToString();

            return usuario;
        }
    }
}
