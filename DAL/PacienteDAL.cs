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
    public class PacienteDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;

        public Paciente ObtenerPorDNI(string dni)
        {
            Paciente paciente = null;

            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"SELECT IdPaciente, Nombre, Apellido, DNI, Telefono, Email, FechaNacimiento FROM Paciente WHERE DNI = @DNI";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DNI", dni);

                    using (var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            paciente = new Paciente
                            {
                                IdPaciente = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                DNI = reader.GetString(3),
                                Telefono = reader.GetString(4),
                                Email = reader.GetString(5),
                                FechaNacimiento = reader.GetDateTime(6)
                            };
                        }
                    }
                }
            }
            return paciente;
        }
        public int Insertar(Paciente paciente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Paciente(Nombre, Apellido, DNI, Telefono, Email, FechaNacimiento)
                            VALUES(@Nombre, @Apellido, @DNI, @Telefono, @Email, @FechaNacimiento);
                            SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                    command.Parameters.AddWithValue("@DNI", paciente.DNI);
                    command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    command.Parameters.AddWithValue("@Email", paciente.Email);
                    command.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}
