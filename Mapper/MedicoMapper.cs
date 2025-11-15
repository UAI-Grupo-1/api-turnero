using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class MedicoMapper
    {
        public static Medico Map(SqlDataReader reader, Medico medico)
        {
            medico.IdMedico = Convert.ToInt32(reader["id_medico"]);
            medico.Nombre = reader["nombre"].ToString();
            medico.Email = reader["email"].ToString();
            medico.IdEspecialidad = Convert.ToInt32(reader["id_especialidad"]);
            
            return medico;
        }

        public static Medico MapWithEspecialidad(SqlDataReader reader, Medico medico)
        {
            // Primero mapear los datos básicos del médico
            Map(reader, medico);
            
            // Luego mapear la especialidad si está disponible en el reader
            try
            {
                int ordinal = reader.GetOrdinal("descripcion");
                if (!reader.IsDBNull(ordinal))
                {
                    medico.Especialidad = new Especialidad
                    {
                        IdEspecialidad = medico.IdEspecialidad,
                        descripcion = reader["descripcion"].ToString()
                    };
                }
            }
            catch (IndexOutOfRangeException)
            {
                // La columna descripcion no existe en el reader, no hacer nada
            }
            
            return medico;
        }
    }
}
