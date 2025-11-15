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
    public class EspecialidadDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;

        public List<Especialidad> ObtenerTodas()
        {
            var especialidades = new List<Especialidad>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT id_especialidad, descripcion FROM Especialidad";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var especialidad = new Especialidad();
                        EspecialidadMapper.Map(reader, especialidad);
                        especialidades.Add(especialidad);
                    }
                }
            }
            return especialidades;
        }
    }
}
