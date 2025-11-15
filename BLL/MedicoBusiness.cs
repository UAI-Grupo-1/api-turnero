using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedicoBusiness
    {
        private MedicoDAL medicoDAL = new MedicoDAL();

        public List<Medico> ObtenerPorEspecialidad(int especialidad)
        {
            List<Medico> medicos = new List<Medico>();
            List<Consultorio> consultorios = new List<Consultorio>();

            medicos = medicoDAL.ObtenerPorEspecialidad(especialidad);

            foreach (var medico in medicos)
            {
                consultorios = medicoDAL.ObtenerConsultoriosPorMedico(medico.IdMedico);
                medico.Consultorios = consultorios;
            }
            return medicos;
        }

        public List<Consultorio> ObtenerConsultoriosPorMedico(int idMedico)
        {
            return medicoDAL.ObtenerConsultoriosPorMedico(idMedico);
        }

        public List<Medico> ObtenerMedicos()
        {
            return medicoDAL.ObtenerTodosLosMedicos();
        }

    }
}
