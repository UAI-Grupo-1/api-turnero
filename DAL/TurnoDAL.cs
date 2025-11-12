using Entities;
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
                var query = @"INSERT INTO Turno (IdMedico, IdPaciente, IdUsuario, Fecha, Hora, Estado, Observaciones)
                            VALUES (@IdMedico, @IdPaciente, @IdUsuario, @Fecha, @Hora, @Estado, @Observaciones);
                            SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMedico", turno.IdMedico);
                    command.Parameters.AddWithValue("@IdPaciente", turno.IdPaciente);
                    command.Parameters.AddWithValue("@IdUsuario", turno.IdUsuario);
                    command.Parameters.AddWithValue("@Fecha", turno.Fecha);
                    command.Parameters.AddWithValue("@Hora", turno.Hora);
                    command.Parameters.AddWithValue("@Estado", turno.Estado);
                    command.Parameters.AddWithValue("@Observaciones", turno.Observaciones);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public bool ExisteTurnoEnFecha(int medicoId, DateTime fecha, TimeSpan hora)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"SELECT COUNT(*) FROM Turno
                            WHERE IdMedico = @IdMedico AND Fecha = @Fecha AND Hora = @Hora AND Estado != 'Cancelado'";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMedico", medicoId);
                    command.Parameters.AddWithValue("@Fecha", fecha);
                    command.Parameters.AddWithValue("@Hora", hora);

                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
        public List<Turno> ObtenerTurnosPorMedicoYFecha(int medicoId, DateTime Fecha)
        {
            var turnos = new List<Turno>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"SELECT t.IdTurno, t.IdMedico, t.IdPaciente, t.Fecha, t.Hora, t.Estado, t.Observaciones,
                            m.Nombre, m.Apellido, p.Nombre, p.Apellido
                            FROM Turno t
                            INNER JOIN Medico m ON t.IdMedico = m.IdMedico
                            INNER JOIN Paciente p ON t.IdPaciente = p.IdPaciente
                            WHERE t.IdMedico = @IdMedico AND t.Fecha = @Fecha
                            ORDER BY t.Hora";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMedico", medicoId);
                    command.Parameters.AddWithValue("@Fecha", Fecha);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            turnos.Add(new Turno
                            {
                                IdTurno = reader.GetInt32(0),
                                IdMedico = reader.GetInt32(1),
                                IdPaciente = reader.GetInt32(2),
                                Fecha = reader.GetDateTime(3),
                                Hora = reader.GetTimeSpan(4),
                                Estado = reader.GetString(5),
                                Observaciones = reader.GetString(6),
                                Medico = new Medico
                                {
                                    Nombre = reader.GetString(7),
                                    Apellido = reader.GetString(8),
                                },
                                Paciente = new Paciente
                                {
                                    Nombre = reader.GetString(9),
                                    Apellido = reader.GetString(10),
                                }
                            });

                        }
                    }
                }
            }
            return turnos;
        }
    }
}
