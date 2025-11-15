using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int IdEspecialidad { get; set; }
        public Especialidad Especialidad { get; set; }
        public List<Consultorio> Consultorios { get; set; }

        // Propiedad para mostrar en el ComboBox
        // Como solo tenemos Nombre, lo usamos directamente
        public string NombreCompleto => Nombre;
    }
}
