using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class ConsultorioMapper
    {
        /*
         * id_consultorio INT PRIMARY KEY IDENTITY(1,1),
         * direccion VARCHAR(150)
         */

        public static Consultorio Map(SqlDataReader reader, Consultorio consultorio)
        {
            consultorio.IdConsultorio = Convert.ToInt32(reader["id_consultorio"]);
            consultorio.Direccion = reader["direccion"].ToString();
            return consultorio;
        }
    }
}
