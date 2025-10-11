using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class PacienteData
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbApiTurnero"].ConnectionString;
    }
}
