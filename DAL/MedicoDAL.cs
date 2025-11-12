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
    public class MedicoDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;

        public List<Medico> ObtenerPorEspecialidad(int especialidad)
        {
            var medicos = new List<Medico>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"SELECT m.IdMedico, m.Nombre, m.Apellido, m.DNI, m.Telefono, m.Email, m.IdEspecialidad,
                      e.NombreEspecialidad 
                      FROM Medico m
                      INNER JOIN Especialidad e ON m.IdEspecialidad = e.IdEspecialidad 
                      WHERE m.IdEspecialidad = @IdEspecialidad";

                using (var command = new SqlCommand(query, connection)) // corrección
                {
                    command.Parameters.AddWithValue("@IdEspecialidad", especialidad);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            medicos.Add(new Medico
                            {
                                IdMedico = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                DNI = reader.GetString(3),
                                Telefono = reader.GetString(4),
                                Email = reader.GetString(5),
                                IdEspecialidad = reader.GetInt32(6),
                                Especialidad = new Especialidad { NombreEspecialidad = reader.GetString(7) }
                            });
                        }
                    }
                }
            }
            return medicos;
        }
        public List<Consultorio> ObtenerConsultoriosPorMedico(int idMedico)
        {
            var consultorios = new List<Consultorio>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"SELECT c.IdConsultorio, c.Nombre, c.Direccion, c.Telefono, c.Email
                             FROM Consultorio c
                             INNER JOIN MedicoConsultorio mc ON c.IdConsultorio = mc.IdConsultorio
                             WHERE mc.IdMedico = @IdMedico";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMedico", idMedico);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
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
            }

            return consultorios;
        }
    }
}
