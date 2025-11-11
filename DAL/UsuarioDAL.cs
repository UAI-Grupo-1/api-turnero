using Entities;
using Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {

        /*
         * 
CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(100)
);
         */

        // Obtener usuario por nombre de usuario
        public Usuario GetUsuarioByUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStringUtil.GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT * FROM Usuario WHERE username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Usuario usuario = UsuarioMapper.Map(reader, new Usuario());
                            return usuario;
                        }
                        else
                        {
                            return null; // Usuario no encontrado
                        }
                    }
                }
            }
        }
    }
}
