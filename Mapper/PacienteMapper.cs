using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class PacienteMapper
    {

        public static Paciente Map(SqlDataReader reader, Paciente paciente)
        {
            paciente.IdPaciente = Convert.ToInt32(reader["id_paciente"]);
            paciente.Nombre = reader["nombre"].ToString();
            paciente.Email = reader["email"].ToString();
            paciente.Telefono = reader["telefono"].ToString();
            paciente.FechaNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]);
            return paciente;
        }
    }
}
