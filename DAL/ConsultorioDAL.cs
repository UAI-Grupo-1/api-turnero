using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConsultorioDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;

        public List<Consultorio> ObtenerTodos()
        {
            var consultorios = new List<Consultorio>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT IdConsultorio, Nombre, Direccion, Telefono, Email FROM Consultorio";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        consultorios.Add(new Consultorio
                        {
                            IdConsultorio = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Direccion = reader.GetString(2),
                            Telefono = reader.GetString(3),
                            Email = reader.GetString(4)
                        });
                    }
                }
            }
            return consultorios;
        }
        public Consultorio ObtenerPorId(int id)
        {
            Consultorio consultorio = null;

            using (var connection = new SqlConnection (connectionString))
            {
                connection.Open();
                var query = "SELECT IdConsultorio, Nombre, Direccion, Telefono, Email FROM Consultorio WHERE IdConsultorio = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            consultorio = new Consultorio
                            {
                                IdConsultorio = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Direccion = reader.GetString(2),
                                Telefono = reader.GetString(3),
                                Email = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return consultorio;
        }

    }
}
