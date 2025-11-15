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
    public class EspecialidadDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;

        public List<Especialidad> ObtenerTodas()
        {
            var especialidades = new List<Especialidad>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT IdEspecialidad, descripcion FROM Especialidad";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        especialidades.Add(new Especialidad
                        {
                            IdEspecialidad = reader.GetInt32(0),
                            descripcion = reader.GetString(1),
                        });
                    }
                }
            }
            return especialidades;
        }
    }
}
