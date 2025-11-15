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

        // Objeto para almacenar el usuario logueado
        // Sirve para saber quien creo un Turno
        private Usuario usuarioActual = null;

        public Form1()
        {
            LogIn();
            /*
             * Credenciales de usuarios de prueba : 
             * usuario = admin / password = admin123
             * usuario = usuario1 / password = clave123
             */

            InitializeComponent();
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

    }
}