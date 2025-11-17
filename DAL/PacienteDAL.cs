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
    public class PacienteDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;

        public Paciente ObtenerPorNombre(string nombre)
        {
            Paciente paciente = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"SELECT id_paciente, nombre, email, telefono, fecha_nacimiento FROM Paciente WHERE nombre = @nombre";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);

                    using (var reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            paciente = PacienteMapper.Map(reader, new Paciente());
                            return paciente;
                        }
                    }
                }
            }
            return null;
        }

        public int Insertar(Paciente paciente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Paciente(nombre, email, telefono, fecha_nacimiento)
                            VALUES(@Nombre, @Email, @Telefono, @FechaNacimiento);
                            SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    command.Parameters.AddWithValue("@Email", paciente.Email);
                    command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    command.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public List<Paciente> ObtenerTodosLosPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"SELECT id_paciente, nombre, email, telefono, fecha_nacimiento FROM Paciente";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Paciente paciente = PacienteMapper.Map(reader, new Paciente());
                            pacientes.Add(paciente);
                        }
                    }
                }
            }
            return pacientes;
        }

        public Paciente ObtenerPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT id_paciente, nombre, email, telefono, fecha_nacimiento FROM Paciente WHERE id_paciente = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return PacienteMapper.Map(reader, new Paciente());
                        }
                    }
                }
            }
            return null;
        }

        public int Actualizar(Paciente paciente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"UPDATE Paciente SET nombre = @Nombre, email = @Email, telefono = @Telefono, fecha_nacimiento = @FechaNacimiento
                              WHERE id_paciente = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    command.Parameters.AddWithValue("@Email", paciente.Email);
                    command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                    command.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                    command.Parameters.AddWithValue("@Id", paciente.IdPaciente);

                    return command.ExecuteNonQuery(); // returns number of rows affected
                }
            }
        }

        public int Eliminar(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"DELETE FROM Paciente WHERE id_paciente = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

    }
}
