using Entities;
using Mapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TurnoDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;

        public int Insertar(Turno turno)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Turno (id_medico, id_paciente, id_usuario, fecha_turno, estado)
                            VALUES (@IdMedico, @IdPaciente, @IdUsuario, @FechaTurno, @Estado);
                            SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMedico", turno.IdMedico);
                    command.Parameters.AddWithValue("@IdPaciente", turno.IdPaciente);
                    command.Parameters.AddWithValue("@IdUsuario", turno.IdUsuario);
                    command.Parameters.AddWithValue("@FechaTurno", turno.FechaHora);
                    command.Parameters.AddWithValue("@Estado", turno.Estado);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<Turno> ObtenerTodosLosTurnos()
        {
            List<Turno> turnos = new List<Turno>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT id_turno, id_medico, id_paciente, id_usuario, fecha_turno, estado FROM Turno";
                
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var turno = TurnoMapper.Map(reader, new Turno());
                        turnos.Add(turno);
                    }
                }
            }
            return turnos;
        }
    }
}
