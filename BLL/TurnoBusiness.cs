using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TurnoBusiness
    {
        private TurnoDAL turnoDAL = new TurnoDAL();
        private MedicoDAL medicoDAL = new MedicoDAL();
        private PacienteDAL pacienteDAL = new PacienteDAL();
        private UsuarioDAL usuarioDAL = new UsuarioDAL();


        public List<Turno> ObtenerTurnos()
        {
            List<Turno> turnos = turnoDAL.ObtenerTodosLosTurnos();
            
            if (turnos == null || turnos.Count == 0) return turnos;
            
            // Por cada turno cargar los datos relacionados
            foreach (var turno in turnos)
            {
                turno.Medico = medicoDAL.ObtenerPorId(turno.IdMedico);
                turno.Paciente = pacienteDAL.ObtenerPorId(turno.IdPaciente);
                turno.Usuario = usuarioDAL.ObtenerPorId(turno.IdUsuario);
            }

            return turnos;
        }

        public int InsertarTurno(Turno turno)
        {
            return turnoDAL.Insertar(turno);
        }

    }
}
