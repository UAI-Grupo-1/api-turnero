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
                      e.descripcion 
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
                            var medico = new Medico();

                            MedicoMapper.Map(reader, medico);
                            medicos.Add(medico);
                            return medicos;
                        }
                    }
                }
                return null;
            }
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

                            Consultorio consultorio = new Consultorio();

                            ConsultorioMapper.Map(reader, consultorio);

                            consultorios.Add(consultorio);
                        }
                    }
                }
            }
            return consultorios;
        }
    }
}
