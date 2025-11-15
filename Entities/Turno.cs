using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
