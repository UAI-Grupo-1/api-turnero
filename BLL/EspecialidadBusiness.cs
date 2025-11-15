using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EspecialidadBusiness
    {
        private EspecialidadDAL especialidadDAL = new EspecialidadDAL();

        public List<Especialidad> ObtenerTodasLasEsp()
        {
            return especialidadDAL.ObtenerTodas();
        }
    }
}
