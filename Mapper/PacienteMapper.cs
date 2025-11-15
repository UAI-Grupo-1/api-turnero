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

        /*
         * IdPaciente, Nombre, Apellido, DNI, Telefono, Email, FechaNacimiento
         */

        public static Paciente Map(SqlDataReader reader, Paciente paciente)
        {
            paciente.IdPaciente = Convert.ToInt32(reader["IdPaciente"]);
            paciente.Nombre = reader["Nombre"].ToString();
            paciente.Apellido = reader["Apellido"].ToString();
            paciente.DNI = reader["DNI"].ToString();
            paciente.Telefono = reader["Telefono"].ToString();
            paciente.Email = reader["Email"].ToString();
            paciente.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
            return paciente;
        }
    }
}
