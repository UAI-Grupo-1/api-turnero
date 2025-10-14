namespace api_turnero
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabAgenda = new TabPage();
            btnConfirmarTurnoAgenda = new Button();
            btnCancelarTurno = new Button();
            dgvAgenda = new DataGridView();
            label2 = new Label();
            dtpAgenda = new DateTimePicker();
            label1 = new Label();
            tabNuevoTurno = new TabPage();
            btnConfirmarTurno = new Button();
            groupBox3 = new GroupBox();
            txtMotivo = new TextBox();
            groupBox2 = new GroupBox();
            listHorarios = new ListBox();
            label6 = new Label();
            dtpFechaTurno = new DateTimePicker();
            label5 = new Label();
            cmbMedicos = new ComboBox();
            label4 = new Label();
            cmbEspecialidades = new ComboBox();
            groupBox1 = new GroupBox();
            lblPacienteSeleccionado = new Label();
            btnNuevoPaciente = new Button();
            btnBuscarPaciente = new Button();
            txtBuscarPaciente = new TextBox();
            label3 = new Label();
            tabPacientes = new TabPage();
            dgvPacientes = new DataGridView();
            btnEliminarPaciente = new Button();
            btnEditarPaciente = new Button();
            btnGuardarPaciente = new Button();
            txtFechaNacimiento = new TextBox();
            label10 = new Label();
            txtTelefono = new TextBox();
            label9 = new Label();
            txtEmail = new TextBox();
            label8 = new Label();
            txtNombrePaciente = new TextBox();
            label7 = new Label();
            tabControl1.SuspendLayout();
            tabAgenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAgenda).BeginInit();
            tabNuevoTurno.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabAgenda);
            tabControl1.Controls.Add(tabNuevoTurno);
            tabControl1.Controls.Add(tabPacientes);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(914, 748);
            tabControl1.TabIndex = 0;
            // 
            // tabAgenda
            // 
            tabAgenda.Controls.Add(btnConfirmarTurnoAgenda);
            tabAgenda.Controls.Add(btnCancelarTurno);
            tabAgenda.Controls.Add(dgvAgenda);
            tabAgenda.Controls.Add(label2);
            tabAgenda.Controls.Add(dtpAgenda);
            tabAgenda.Controls.Add(label1);
            tabAgenda.Location = new Point(4, 29);
            tabAgenda.Margin = new Padding(3, 4, 3, 4);
            tabAgenda.Name = "tabAgenda";
            tabAgenda.Padding = new Padding(3, 4, 3, 4);
            tabAgenda.Size = new Size(906, 715);
            tabAgenda.TabIndex = 0;
            tabAgenda.Text = "Agenda de Turnos";
            tabAgenda.UseVisualStyleBackColor = true;
            tabAgenda.Click += tabAgenda_Click;
            // 
            // btnConfirmarTurnoAgenda
            // 
            btnConfirmarTurnoAgenda.Location = new Point(715, 656);
            btnConfirmarTurnoAgenda.Margin = new Padding(3, 4, 3, 4);
            btnConfirmarTurnoAgenda.Name = "btnConfirmarTurnoAgenda";
            btnConfirmarTurnoAgenda.Size = new Size(181, 31);
            btnConfirmarTurnoAgenda.TabIndex = 5;
            btnConfirmarTurnoAgenda.Text = "Confirmar Turno";
            btnConfirmarTurnoAgenda.UseVisualStyleBackColor = true;
            // 
            // btnCancelarTurno
            // 
            btnCancelarTurno.Location = new Point(528, 656);
            btnCancelarTurno.Margin = new Padding(3, 4, 3, 4);
            btnCancelarTurno.Name = "btnCancelarTurno";
            btnCancelarTurno.Size = new Size(181, 31);
            btnCancelarTurno.TabIndex = 4;
            btnCancelarTurno.Text = "Cancelar Turno";
            btnCancelarTurno.UseVisualStyleBackColor = true;
            // 
            // dgvAgenda
            // 
            dgvAgenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAgenda.Location = new Point(9, 95);
            dgvAgenda.Margin = new Padding(3, 4, 3, 4);
            dgvAgenda.Name = "dgvAgenda";
            dgvAgenda.RowHeadersWidth = 51;
            dgvAgenda.Size = new Size(887, 553);
            dgvAgenda.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 71);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 2;
            label2.Text = "Turnos del Día:";
            // 
            // dtpAgenda
            // 
            dtpAgenda.Location = new Point(138, 20);
            dtpAgenda.Margin = new Padding(3, 4, 3, 4);
            dtpAgenda.Name = "dtpAgenda";
            dtpAgenda.Size = new Size(255, 27);
            dtpAgenda.TabIndex = 1;
            dtpAgenda.ValueChanged += dtpAgenda_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 28);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 0;
            label1.Text = "Seleccionar Fecha:";
            // 
            // tabNuevoTurno
            // 
            tabNuevoTurno.Controls.Add(btnConfirmarTurno);
            tabNuevoTurno.Controls.Add(groupBox3);
            tabNuevoTurno.Controls.Add(groupBox2);
            tabNuevoTurno.Controls.Add(groupBox1);
            tabNuevoTurno.Location = new Point(4, 29);
            tabNuevoTurno.Margin = new Padding(3, 4, 3, 4);
            tabNuevoTurno.Name = "tabNuevoTurno";
            tabNuevoTurno.Padding = new Padding(3, 4, 3, 4);
            tabNuevoTurno.Size = new Size(906, 715);
            tabNuevoTurno.TabIndex = 1;
            tabNuevoTurno.Text = "Nuevo Turno";
            tabNuevoTurno.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarTurno
            // 
            btnConfirmarTurno.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnConfirmarTurno.Location = new Point(661, 628);
            btnConfirmarTurno.Margin = new Padding(3, 4, 3, 4);
            btnConfirmarTurno.Name = "btnConfirmarTurno";
            btnConfirmarTurno.Size = new Size(235, 72);
            btnConfirmarTurno.TabIndex = 3;
            btnConfirmarTurno.Text = "Confirmar Turno";
            btnConfirmarTurno.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtMotivo);
            groupBox3.Location = new Point(9, 508);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(887, 112);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Motivo de la Consulta";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(7, 29);
            txtMotivo.Margin = new Padding(3, 4, 3, 4);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(873, 73);
            txtMotivo.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listHorarios);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(dtpFechaTurno);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cmbMedicos);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cmbEspecialidades);
            groupBox2.Location = new Point(9, 171);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(887, 329);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalles del Turno";
            // 
            // listHorarios
            // 
            listHorarios.FormattingEnabled = true;
            listHorarios.Location = new Point(18, 189);
            listHorarios.Margin = new Padding(3, 4, 3, 4);
            listHorarios.Name = "listHorarios";
            listHorarios.Size = new Size(850, 124);
            listHorarios.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(449, 41);
            label6.Name = "label6";
            label6.Size = new Size(114, 20);
            label6.TabIndex = 5;
            label6.Text = "Fecha del Turno";
            // 
            // dtpFechaTurno
            // 
            dtpFechaTurno.Location = new Point(449, 65);
            dtpFechaTurno.Margin = new Padding(3, 4, 3, 4);
            dtpFechaTurno.Name = "dtpFechaTurno";
            dtpFechaTurno.Size = new Size(278, 27);
            dtpFechaTurno.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 104);
            label5.Name = "label5";
            label5.Size = new Size(59, 20);
            label5.TabIndex = 3;
            label5.Text = "Médico";
            // 
            // cmbMedicos
            // 
            cmbMedicos.FormattingEnabled = true;
            cmbMedicos.Location = new Point(18, 128);
            cmbMedicos.Margin = new Padding(3, 4, 3, 4);
            cmbMedicos.Name = "cmbMedicos";
            cmbMedicos.Size = new Size(374, 28);
            cmbMedicos.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 41);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 1;
            label4.Text = "Especialidad";
            // 
            // cmbEspecialidades
            // 
            cmbEspecialidades.FormattingEnabled = true;
            cmbEspecialidades.Location = new Point(18, 65);
            cmbEspecialidades.Margin = new Padding(3, 4, 3, 4);
            cmbEspecialidades.Name = "cmbEspecialidades";
            cmbEspecialidades.Size = new Size(374, 28);
            cmbEspecialidades.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblPacienteSeleccionado);
            groupBox1.Controls.Add(btnNuevoPaciente);
            groupBox1.Controls.Add(btnBuscarPaciente);
            groupBox1.Controls.Add(txtBuscarPaciente);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(9, 8);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(887, 155);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Paciente";
            // 
            // lblPacienteSeleccionado
            // 
            lblPacienteSeleccionado.AutoSize = true;
            lblPacienteSeleccionado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPacienteSeleccionado.Location = new Point(18, 117);
            lblPacienteSeleccionado.Name = "lblPacienteSeleccionado";
            lblPacienteSeleccionado.Size = new Size(231, 20);
            lblPacienteSeleccionado.TabIndex = 4;
            lblPacienteSeleccionado.Text = "Paciente Seleccionado: Ninguno";
            // 
            // btnNuevoPaciente
            // 
            btnNuevoPaciente.Location = new Point(739, 59);
            btnNuevoPaciente.Margin = new Padding(3, 4, 3, 4);
            btnNuevoPaciente.Name = "btnNuevoPaciente";
            btnNuevoPaciente.Size = new Size(141, 31);
            btnNuevoPaciente.TabIndex = 3;
            btnNuevoPaciente.Text = "Nuevo Paciente";
            btnNuevoPaciente.UseVisualStyleBackColor = true;
            // 
            // btnBuscarPaciente
            // 
            btnBuscarPaciente.Location = new Point(590, 59);
            btnBuscarPaciente.Margin = new Padding(3, 4, 3, 4);
            btnBuscarPaciente.Name = "btnBuscarPaciente";
            btnBuscarPaciente.Size = new Size(143, 31);
            btnBuscarPaciente.TabIndex = 2;
            btnBuscarPaciente.Text = "Buscar";
            btnBuscarPaciente.UseVisualStyleBackColor = true;
            // 
            // txtBuscarPaciente
            // 
            txtBuscarPaciente.Location = new Point(18, 60);
            txtBuscarPaciente.Margin = new Padding(3, 4, 3, 4);
            txtBuscarPaciente.Name = "txtBuscarPaciente";
            txtBuscarPaciente.Size = new Size(564, 27);
            txtBuscarPaciente.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 36);
            label3.Name = "label3";
            label3.Size = new Size(240, 20);
            label3.TabIndex = 0;
            label3.Text = "Buscar Paciente por Nombre o DNI";
            // 
            // tabPacientes
            // 
            tabPacientes.Controls.Add(dgvPacientes);
            tabPacientes.Controls.Add(btnEliminarPaciente);
            tabPacientes.Controls.Add(btnEditarPaciente);
            tabPacientes.Controls.Add(btnGuardarPaciente);
            tabPacientes.Controls.Add(txtFechaNacimiento);
            tabPacientes.Controls.Add(label10);
            tabPacientes.Controls.Add(txtTelefono);
            tabPacientes.Controls.Add(label9);
            tabPacientes.Controls.Add(txtEmail);
            tabPacientes.Controls.Add(label8);
            tabPacientes.Controls.Add(txtNombrePaciente);
            tabPacientes.Controls.Add(label7);
            tabPacientes.Location = new Point(4, 29);
            tabPacientes.Margin = new Padding(3, 4, 3, 4);
            tabPacientes.Name = "tabPacientes";
            tabPacientes.Size = new Size(906, 715);
            tabPacientes.TabIndex = 2;
            tabPacientes.Text = "Gestión de Pacientes";
            tabPacientes.UseVisualStyleBackColor = true;
            // 
            // dgvPacientes
            // 
            dgvPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPacientes.Location = new Point(9, 252);
            dgvPacientes.Margin = new Padding(3, 4, 3, 4);
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.RowHeadersWidth = 51;
            dgvPacientes.Size = new Size(887, 448);
            dgvPacientes.TabIndex = 11;
            // 
            // btnEliminarPaciente
            // 
            btnEliminarPaciente.Location = new Point(312, 197);
            btnEliminarPaciente.Margin = new Padding(3, 4, 3, 4);
            btnEliminarPaciente.Name = "btnEliminarPaciente";
            btnEliminarPaciente.Size = new Size(127, 31);
            btnEliminarPaciente.TabIndex = 10;
            btnEliminarPaciente.Text = "Eliminar";
            btnEliminarPaciente.UseVisualStyleBackColor = true;
            // 
            // btnEditarPaciente
            // 
            btnEditarPaciente.Location = new Point(178, 197);
            btnEditarPaciente.Margin = new Padding(3, 4, 3, 4);
            btnEditarPaciente.Name = "btnEditarPaciente";
            btnEditarPaciente.Size = new Size(127, 31);
            btnEditarPaciente.TabIndex = 9;
            btnEditarPaciente.Text = "Editar";
            btnEditarPaciente.UseVisualStyleBackColor = true;
            // 
            // btnGuardarPaciente
            // 
            btnGuardarPaciente.Location = new Point(45, 197);
            btnGuardarPaciente.Margin = new Padding(3, 4, 3, 4);
            btnGuardarPaciente.Name = "btnGuardarPaciente";
            btnGuardarPaciente.Size = new Size(127, 31);
            btnGuardarPaciente.TabIndex = 8;
            btnGuardarPaciente.Text = "Guardar";
            btnGuardarPaciente.UseVisualStyleBackColor = true;
            // 
            // txtFechaNacimiento
            // 
            txtFechaNacimiento.Location = new Point(518, 136);
            txtFechaNacimiento.Margin = new Padding(3, 4, 3, 4);
            txtFechaNacimiento.Name = "txtFechaNacimiento";
            txtFechaNacimiento.Size = new Size(342, 27);
            txtFechaNacimiento.TabIndex = 7;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(518, 112);
            label10.Name = "label10";
            label10.Size = new Size(149, 20);
            label10.TabIndex = 6;
            label10.Text = "Fecha de Nacimiento";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(45, 136);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(342, 27);
            txtTelefono.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(45, 112);
            label9.Name = "label9";
            label9.Size = new Size(67, 20);
            label9.TabIndex = 4;
            label9.Text = "Teléfono";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(518, 55);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(342, 27);
            txtEmail.TabIndex = 3;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(518, 31);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 2;
            label8.Text = "Email";
            // 
            // txtNombrePaciente
            // 
            txtNombrePaciente.Location = new Point(45, 55);
            txtNombrePaciente.Margin = new Padding(3, 4, 3, 4);
            txtNombrePaciente.Name = "txtNombrePaciente";
            txtNombrePaciente.Size = new Size(342, 27);
            txtNombrePaciente.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 31);
            label7.Name = "label7";
            label7.Size = new Size(134, 20);
            label7.TabIndex = 0;
            label7.Text = "Nombre Completo";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 748);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Sistema de Gestión de Turnos Médicos";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabAgenda.ResumeLayout(false);
            tabAgenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAgenda).EndInit();
            tabNuevoTurno.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPacientes.ResumeLayout(false);
            tabPacientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabAgenda;
        private TabPage tabNuevoTurno;
        private TabPage tabPacientes;
        private Label label1;
        private DateTimePicker dtpAgenda;
        private Label label2;
        private DataGridView dgvAgenda;
        private Button btnCancelarTurno;
        private Button btnConfirmarTurnoAgenda;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox txtBuscarPaciente;
        private Button btnBuscarPaciente;
        private Button btnNuevoPaciente;
        private Label lblPacienteSeleccionado;
        private GroupBox groupBox2;
        private Label label4;
        private ComboBox cmbEspecialidades;
        private Label label5;
        private ComboBox cmbMedicos;
        private Label label6;
        private DateTimePicker dtpFechaTurno;
        private ListBox listHorarios;
        private GroupBox groupBox3;
        private TextBox txtMotivo;
        private Button btnConfirmarTurno;
        private Label label7;
        private TextBox txtNombrePaciente;
        private Label label8;
        private TextBox txtEmail;
        private Label label9;
        private TextBox txtTelefono;
        private Label label10;
        private TextBox txtFechaNacimiento;
        private Button btnGuardarPaciente;
        private Button btnEditarPaciente;
        private Button btnEliminarPaciente;
        private DataGridView dgvPacientes;
    }
}