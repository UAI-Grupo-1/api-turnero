using System.Data;
using System.Windows.Forms;
using BLL;
using Entities;
using Microsoft.VisualBasic;

namespace api_turnero
{
    public partial class Form1 : Form
    {
        /*************************
         * Instancias de Servicios
         ************************/
        private UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
        private TurnoBusiness turnoBusiness = new TurnoBusiness();
        private EspecialidadBusiness especialidadBusiness = new EspecialidadBusiness();
        private PacienteBusiness pacienteBusiness = new PacienteBusiness();


        // Objeto para almacenar el usuario logueado
        // Sirve para saber quien creo un Turno
        private Usuario usuarioActual = null;

        // Guardar id del paciente que estamos editando
        private int? pacienteEditandoId = null;

        public Form1()
        {
            LogIn();
            /*
             * Credenciales de usuarios de prueba : 
             * usuario = admin / password = admin123
             * usuario = usuario1 / password = clave123
             */

            InitializeComponent();

            // Carga de datos en Agendas / Grid / Combobox
            LoadTurnos();
            LoadEspecialidades();
            LoadMedicos();
            LoadPacientes();
            LoadPacientesInCmb();

            //metodo par ahorarios
            LoadHorarios();

            // Wire up botones de editar/eliminar/confirmar
            btnEditarPaciente.Click += BtnEditarPaciente_Click;
            btnConfirmarCambios.Click += BtnConfirmarCambios_Click;
            btnEliminarPaciente.Click += BtnEliminarPaciente_Click;

            // Al hacer click en la fila del dgv, seleccionar la fila
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.MultiSelect = false;
        }

        private void LogIn()
        {
            bool canLogIn = false;

            string username = Interaction.InputBox("Ingrese su nombre de usuario:", "Login", "admin");
            string password = Interaction.InputBox("Ingrese su contraseña:", "Login", "admin123");

            Usuario usuario = this.usuarioBusiness.GetUserByName(username);
            if (usuario == null)
            {
                MessageBox.Show("Usuario no encontrado. La aplicación se cerrará.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                canLogIn = usuarioBusiness.ValidarCredenciales(username, password);
            }

            if (!canLogIn)
            {
                string optionElegida = Interaction.InputBox("Presione 0 si quiere continuar sin Iniciar Sesión");
                if (optionElegida == "0")
                {
                    return;
                }
                else
                {
                    usuario = this.usuarioBusiness.GetUserByName(username);
                    LogIn();
                }
            }
            else
            {
                usuarioActual = usuario;
                MessageBox.Show($"Bienvenido, {usuarioActual.Username}!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Data Table - Muestra la lista de Turno
        private void LoadTurnos()
        {
            List<Turno> turnos = turnoBusiness.ObtenerTurnos();

            if (null == turnos) return;

            DataTable dt = new DataTable();

            // Definir columnas del DataTable
            dt.Columns.Add("ID Turno", typeof(int));
            dt.Columns.Add("Fecha/Hora", typeof(DateTime));
            dt.Columns.Add("Médico", typeof(string));
            dt.Columns.Add("Especialidad", typeof(string));
            dt.Columns.Add("Paciente", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            // Llenar el DataTable con los datos de los turnos
            foreach (Turno turno in turnos)
            {
                dt.Rows.Add(
                    turno.IdTurno,
                    turno.FechaHora,
                    turno.Medico?.Nombre ?? "N/A",
                    turno.Medico?.Especialidad?.descripcion ?? "N/A",
                    turno.Paciente?.Nombre ?? "N/A",
                    turno.Estado ?? "N/A"
                );
            }

            // Asignar el DataTable al DataGridView
            dgvAgenda.DataSource = dt;

            // Opcional: Ajustar el ancho de las columnas
            dgvAgenda.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // ComboBox Especialidades - Carga y muestra todas las Especialidades 
        private void LoadEspecialidades()
        {
            List<Especialidad> especialidades = especialidadBusiness.ObtenerTodasLasEsp();

            if (null == especialidades) return;

            cmbEspecialidades.Items.Clear();

            // Agregar cada especialidad al el ComboBox
            foreach (Especialidad especialidad in especialidades)
            {
                cmbEspecialidades.Items.Add(especialidad);
            }

            // Configurar DisplayMember y ValueMember
            cmbEspecialidades.DisplayMember = "descripcion";
            cmbEspecialidades.ValueMember = "IdEspecialidad";

            // Opcional: Seleccionar el primer item por defecto
            if (cmbEspecialidades.Items.Count > 0)
            {
                cmbEspecialidades.SelectedIndex = 0;
            }
        }

        // Combobox Medico - Carga y muestra los Medicos
        private void LoadMedicos()
        {
            MedicoBusiness medicoBusiness = new MedicoBusiness();
            List<Medico> medicos = medicoBusiness.ObtenerMedicos();
            if (null == medicos) return;
            cmbMedicos.Items.Clear();
            // Agregar cada médico al ComboBox
            foreach (Medico medico in medicos)
            {
                cmbMedicos.Items.Add(medico);
            }
            // Configurar DisplayMember y ValueMember
            cmbMedicos.DisplayMember = "NombreCompleto"; // Asumiendo que tienes una propiedad NombreCompleto en Medico
            cmbMedicos.ValueMember = "IdMedico";
            // Opcional: Seleccionar el primer item por defecto
            if (cmbMedicos.Items.Count > 0)
            {
                cmbMedicos.SelectedIndex = 0;
            }
        }

        // Guardar Paciente nuevo
        private void btnGuardarPaciente_Click(object sender, EventArgs e)
        {
            // Validar que los campos requeridos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombrePaciente.Text))
            {
                MessageBox.Show("El nombre del paciente es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombrePaciente.Text;
            string email = txtEmail.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            // Parsear fecha de nacimiento desde TextBox
            DateTime fechaNacimiento;
            if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            {
                MessageBox.Show("Fecha de nacimiento inválida. Use formato: dd/MM/yyyy o yyyy-MM-dd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Paciente nuevoPaciente = new Paciente
            {
                Nombre = nombre,
                Email = email,
                Telefono = telefono,
                FechaNacimiento = fechaNacimiento
            };

            try
            {
                pacienteBusiness.AgregarPaciente(nuevoPaciente);
                MessageBox.Show("Paciente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos
                txtNombrePaciente.Clear();
                txtEmail.Clear();
                txtTelefono.Clear();
                txtFechaNacimiento.Clear();

                LoadPacientes();
                LoadPacientesInCmb();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga y muestra los Pacientes
        private void LoadPacientes()
        {
            List<Paciente> pacientes = pacienteBusiness.ObtenerTodosLosPacientes();

            if (null == pacientes) return;

            DataTable dt = new DataTable();

            // Definir columnas
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Teléfono", typeof(string));
            dt.Columns.Add("Fecha Nacimiento", typeof(DateTime));

            // Llenar el DataTable con los datos de los pacientes
            foreach (Paciente paciente in pacientes)
            {
                dt.Rows.Add(
                    paciente.IdPaciente,
                    paciente.Nombre,
                    paciente.Email,
                    paciente.Telefono,
                    paciente.FechaNacimiento
                );
            }

            // Asignar el DataTable al DataGridView
            dgvPacientes.DataSource = dt;

            // Ajusta el ancho de las columnas
            dgvPacientes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // Buscar Paciente por Nombre
        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            string nombreBusqueda = txtBuscarPaciente.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombreBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un Nombre para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Paciente paciente = pacienteBusiness.ObtenerPacientePorNombre(nombreBusqueda);
            if (paciente != null)
            {
                MessageBox.Show($"Paciente encontrado: {paciente.Nombre}, Email: {paciente.Email}, Teléfono: {paciente.Telefono}", "Paciente Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Paciente no encontrado.", "Resultado de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Cargar Pacientes en ComboBox
        private void LoadPacientesInCmb()
        {
            List<Paciente> pacientes = pacienteBusiness.ObtenerTodosLosPacientes();
            if (null == pacientes) return;
            comboBox1.Items.Clear();
            // Agregar cada paciente al ComboBox
            foreach (Paciente paciente in pacientes)
            {
                comboBox1.Items.Add(paciente);
            }
            // Configurar DisplayMember y ValueMember
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdPaciente";
            // Opcional: Seleccionar el primer item por defecto
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        // Editar paciente: carga los datos del paciente seleccionado en los textboxes
        private void BtnEditarPaciente_Click(object? sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvPacientes.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);

            Paciente p = pacienteBusiness.ObtenerPorId(id);
            if (p == null)
            {
                MessageBox.Show("No se encontró el paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pacienteEditandoId = p.IdPaciente;
            txtNombrePaciente.Text = p.Nombre;
            txtEmail.Text = p.Email;
            txtTelefono.Text = p.Telefono;
            txtFechaNacimiento.Text = p.FechaNacimiento.ToString("yyyy-MM-dd");
        }

        // Confirmar cambios: actualiza el paciente en la base de datos
        private void BtnConfirmarCambios_Click(object? sender, EventArgs e)
        {
            if (pacienteEditandoId == null)
            {
                MessageBox.Show("No hay ningún paciente en edición.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validaciones mínimas
            if (string.IsNullOrWhiteSpace(txtNombrePaciente.Text))
            {
                MessageBox.Show("El nombre del paciente es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaNacimiento;
            if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            {
                MessageBox.Show("Fecha de nacimiento inválida. Use formato: dd/MM/yyyy o yyyy-MM-dd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Paciente actualizado = new Paciente
            {
                IdPaciente = pacienteEditandoId.Value,
                Nombre = txtNombrePaciente.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                FechaNacimiento = fechaNacimiento
            };

            try
            {
                int rows = pacienteBusiness.ActualizarPaciente(actualizado);
                if (rows > 0)
                {
                    MessageBox.Show("Paciente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar estado de edición
                    pacienteEditandoId = null;
                    txtNombrePaciente.Clear();
                    txtEmail.Clear();
                    txtTelefono.Clear();
                    txtFechaNacimiento.Clear();

                    LoadPacientes();
                    LoadPacientesInCmb();
                }
                else
                {
                    MessageBox.Show("No se modificó ningún registro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminar paciente seleccionado
        private void BtnEliminarPaciente_Click(object? sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvPacientes.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar el paciente seleccionado?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                int rows = pacienteBusiness.EliminarPaciente(id);
                if (rows > 0)
                {
                    MessageBox.Show("Paciente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPacientes();
                    LoadPacientesInCmb();
                }
                else
                {
                    MessageBox.Show("No se eliminó ningún registro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el paciente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Crear Turno
        private void btnConfirmarTurno_Click(object sender, EventArgs e)
        {
            if (cmbMedicos.SelectedItem == null || cmbEspecialidades.SelectedItem == null || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un médico, especialidad y paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbHorarios.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Medico medicoSeleccionado = (Medico)cmbMedicos.SelectedItem;
            Especialidad especialidadSeleccionada = (Especialidad)cmbEspecialidades.SelectedItem;
            Paciente pacienteSeleccionado = (Paciente)comboBox1.SelectedItem;

            //Fecha seleccionada en el DateTimePicker
            DateTime fecha = dtpFechaTurno.Value.Date;

            //Horario seleccionado en el combo
            string hora = cmbHorarios.SelectedItem.ToString();

            //Combinar fecha + hora correctamente
            DateTime fechaTurno = DateTime.Parse($"{fecha:yyyy-MM-dd} {hora}");

            Turno nuevoTurno = new Turno
            {
                IdMedico = medicoSeleccionado.IdMedico,
                IdPaciente = pacienteSeleccionado.IdPaciente,
                IdUsuario = usuarioActual?.IdUsuario ?? 0,
                FechaHora = fechaTurno,
                Estado = "Programado",
                Medico = medicoSeleccionado,
                Paciente = pacienteSeleccionado,
                Usuario = usuarioActual
            };

            try
            {
                turnoBusiness.InsertarTurno(nuevoTurno);
                MessageBox.Show("Turno creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTurnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el turno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadHorarios()
        {
            DateTime inicio = DateTime.Today.AddHours(8);   // 08:00
            DateTime fin = DateTime.Today.AddHours(14);     // 14:00
            TimeSpan intervalo = TimeSpan.FromMinutes(30);  // Turnos cada 30 minutos

            cmbHorarios.Items.Clear();

            while (inicio <= fin)
            {
                cmbHorarios.Items.Add(inicio.ToString("HH:mm"));
                inicio = inicio.Add(intervalo);
            }

            if (cmbHorarios.Items.Count > 0)
                cmbHorarios.SelectedIndex = 0;
        }

        private void btnConfirmarCambios_Click_1(object sender, EventArgs e)
        {
            // Forward to the implemented confirmation handler so the designer-assigned event works.
            BtnConfirmarCambios_Click(sender, e);
        }
    }
}