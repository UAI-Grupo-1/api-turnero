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
    public class ConsultorioDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;

        public List<Consultorio> ObtenerTodos()
        {
            var consultorios = new List<Consultorio>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT IdConsultorio, direccion FROM Consultorio";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Consultorio consultorio = new Consultorio();

                        ConsultorioMapper.Map(reader, consultorio);

                        consultorios.Add(consultorio);
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
                var query = "SELECT IdConsultorio, direccion FROM Consultorio WHERE IdConsultorio = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return ConsultorioMapper.Map(reader, new Consultorio());
                        }
                    }
                }
                return null;
            }
        }
    }
}
