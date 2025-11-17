using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PacienteBusiness
    {
        private PacienteDAL pacienteDAL = new PacienteDAL();

        public List<Paciente> ObtenerTodosLosPacientes()
        {
            return pacienteDAL.ObtenerTodosLosPacientes();
        }

        public void AgregarPaciente(Paciente paciente)
        {
            pacienteDAL.Insertar(paciente);
        }

        public Paciente ObtenerPacientePorNombre(string nombre)
        {
            return pacienteDAL.ObtenerPorNombre(nombre);
        }

        public Paciente ObtenerPorId(int id)
        {
            return pacienteDAL.ObtenerPorId(id);
        }

        public int ActualizarPaciente(Paciente paciente)
        {
            return pacienteDAL.Actualizar(paciente);
        }

        public int EliminarPaciente(int id)
        {
            return pacienteDAL.Eliminar(id);
        }

    }
}
