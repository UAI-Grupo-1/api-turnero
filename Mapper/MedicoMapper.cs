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
            medico.Especialidad = EspecialidadMapper.Map(reader, new Especialidad());
            return medico;
        }

    }
}
