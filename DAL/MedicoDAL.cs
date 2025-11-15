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
                var query = @"SELECT m.id_medico, m.nombre, m.email, m.id_especialidad,
                      e.descripcion 
                      FROM Medico m
                      INNER JOIN Especialidad e ON m.id_especialidad = e.id_especialidad 
                      WHERE m.id_especialidad = @IdEspecialidad";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdEspecialidad", especialidad);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var medico = new Medico();
                            MedicoMapper.MapWithEspecialidad(reader, medico);
                            medicos.Add(medico);
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
                var query = @"SELECT c.IdConsultorio, c.direccion
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

        public List<Medico> ObtenerTodosLosMedicos()
        {
            List<Medico> medicos = new List<Medico>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_medico, nombre, email, id_especialidad FROM Medico";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Medico medico = new Medico();
                        MedicoMapper.Map(reader, medico);
                        medicos.Add(medico);
                    }
                }
            }
            return medicos;
        }

        public Medico ObtenerPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"SELECT m.id_medico, m.nombre, m.email, m.id_especialidad, e.descripcion
                             FROM Medico m
                             LEFT JOIN Especialidad e ON m.id_especialidad = e.id_especialidad
                             WHERE m.id_medico = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MedicoMapper.MapWithEspecialidad(reader, new Medico());
                        }
                    }
                }
            }
            return null;
        }
    }
}
//#nullable disable
