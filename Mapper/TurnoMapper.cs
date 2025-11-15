using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class TurnoMapper
    {
        public static Turno Map(SqlDataReader reader, Turno turno)
        {
            // Mapear los datos del SqlDataReader a una instancia de Turno
            /*
             * 
                IdMedico, IdPaciente, IdUsuario, Fecha, Hora, Estado, Observaciones
             */
            turno.IdTurno = Convert.ToInt32(reader["IdTurno"]);
            turno.IdMedico = Convert.ToInt32(reader["IdMedico"]);
            turno.IdPaciente = Convert.ToInt32(reader["IdPaciente"]);
            turno.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
            turno.Fecha = Convert.ToDateTime(reader["Fecha"]);
            turno.Hora = (TimeSpan)(reader["Hora"]);
            turno.Estado = reader["Estado"].ToString();
            turno.Observaciones = reader["Observaciones"].ToString();

            return turno;
        }
    }
}
