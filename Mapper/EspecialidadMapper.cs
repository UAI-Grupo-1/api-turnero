using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class EspecialidadMapper
    {
        /*
         * id_especialidad INT PRIMARY KEY IDENTITY(1,1),
         * descripcion VARCHAR(100)
         */

        public static Especialidad Map(SqlDataReader reader, Especialidad especialidad)
        {
            especialidad.IdEspecialidad = Convert.ToInt32(reader["id_especialidad"]);
            especialidad.descripcion = reader["descripcion"].ToString();
            return especialidad;
        }
    }
}
