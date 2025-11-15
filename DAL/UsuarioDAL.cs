using Entities;
using Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;

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

        public Usuario ObtenerPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT id_usuario, username, password, email FROM Usuario WHERE id_usuario = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return UsuarioMapper.Map(reader, new Usuario());
                        }
                    }
                }
            }
            return null;
        }
    }
}
