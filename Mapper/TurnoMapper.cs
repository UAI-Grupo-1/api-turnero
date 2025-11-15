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
            // Columnas: id_turno, id_medico, id_paciente, id_usuario, fecha_turno, estado
            turno.IdTurno = Convert.ToInt32(reader["id_turno"]);
            turno.IdMedico = Convert.ToInt32(reader["id_medico"]);
            turno.IdPaciente = Convert.ToInt32(reader["id_paciente"]);
            turno.IdUsuario = Convert.ToInt32(reader["id_usuario"]);
            turno.FechaHora = Convert.ToDateTime(reader["fecha_turno"]);
            turno.Estado = reader["estado"].ToString();

            return turno;
        }
    }
}
