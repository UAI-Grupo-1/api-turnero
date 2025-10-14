using System.Data;

namespace api_turnero
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Carga inicial de datos al abrir el formulario
            CargarEspecialidades();
            ConfigurarGrillas();

            // Asignar eventos
            cmbEspecialidades.SelectedIndexChanged += cmbEspecialidades_SelectedIndexChanged;
            dtpFechaTurno.ValueChanged += dtpFechaTurno_ValueChanged;
            btnBuscarPaciente.Click += btnBuscarPaciente_Click;
            btnConfirmarTurno.Click += btnConfirmarTurno_Click;
        }

        private void ConfigurarGrillas()
        {
            // Configura las columnas para la grilla de agenda
            dgvAgenda.AutoGenerateColumns = false;
            dgvAgenda.Columns.Add("Hora", "Hora");
            dgvAgenda.Columns.Add("Paciente", "Paciente");
            dgvAgenda.Columns.Add("Medico", "Médico");
            dgvAgenda.Columns.Add("Especialidad", "Especialidad");
            dgvAgenda.Columns.Add("Estado", "Estado");
            dgvAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // TODO: Configurar la grilla de pacientes (dgvPacientes)
        }

        private void CargarEspecialidades()
        {
            // TODO: Aquí deberías llamar a tu BLL para obtener las especialidades desde la DB
            // Por ahora, simulamos los datos
            var especialidades = new List<string>
            {
                "Odontología",
                "Pediatría",
                "Cirugía",
                "Enfermería"
            };
            cmbEspecialidades.DataSource = especialidades;
        }

        private void CargarMedicosPorEspecialidad(string especialidad)
        {
            // TODO: Llamar a la BLL para obtener médicos según la especialidad
            // Simulación:
            var medicos = new List<string>();
            if (especialidad == "Odontología")
            {
                medicos.Add("Jose Migrañas ");
            }
            else if (especialidad == "Pediatría")
            {
                medicos.Add("Angela Leiva");
            }
            else if (especialidad == "Cirugía")
            {
                medicos.Add("Juan Genitales");
            }
            else
            {
                medicos.Add("Carla Guardia");
            }
            cmbMedicos.DataSource = medicos;
        }

        private void CargarHorariosDisponibles(string medico, DateTime fecha)
        {
            // TODO: Lógica compleja en la BLL para ver los turnos ocupados
            // y devolver solo los horarios libres para ese médico y fecha.
            // Simulación:
            listHorarios.Items.Clear();
            var horarios = new List<string>
            {
                "09:00", "09:30", "10:00", "10:30", "11:00",
                "14:00", "14:30", "15:00", "15:30"
            };
            listHorarios.DataSource = horarios;
        }


        // --- Eventos de los Controles ---

        private void cmbEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecialidades.SelectedItem != null)
            {
                string especialidadSeleccionada = cmbEspecialidades.SelectedItem.ToString();
                CargarMedicosPorEspecialidad(especialidadSeleccionada);
            }
        }

        private void dtpFechaTurno_ValueChanged(object sender, EventArgs e)
        {
            if (cmbMedicos.SelectedItem != null)
            {
                string medico = cmbMedicos.SelectedItem.ToString();
                DateTime fecha = dtpFechaTurno.Value;
                CargarHorariosDisponibles(medico, fecha);
            }
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscarPaciente.Text;
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                MessageBox.Show("Por favor, ingrese un nombre o DNI para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Llamar a la BLL para buscar el paciente en la DB
            // Simulación de un paciente encontrado:
            lblPacienteSeleccionado.Text = "Paciente Seleccionado: Juan Pérez (ID: 1)";
        }


        private void btnConfirmarTurno_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (lblPacienteSeleccionado.Text.Contains("Ninguno"))
            {
                MessageBox.Show("Debe seleccionar un paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (listHorarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recopilar datos
            string paciente = lblPacienteSeleccionado.Text;
            string especialidad = cmbEspecialidades.SelectedItem.ToString();
            string medico = cmbMedicos.SelectedItem.ToString();
            DateTime fecha = dtpFechaTurno.Value.Date;
            string hora = listHorarios.SelectedItem.ToString();
            string motivo = txtMotivo.Text;

            // TODO: Llamar a la BLL para guardar la solicitud y el turno en la DB

            MessageBox.Show($"Turno confirmado para {paciente}\n" +
                            $"Día: {fecha:dd/MM/yyyy} a las {hora} hs.\n" +
                            $"Con el Dr/a. {medico} ({especialidad}).",
                            "Turno Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar formulario
            // ...
        }

        private void dtpAgenda_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabAgenda_Click(object sender, EventArgs e)
        {

        }
    }
}