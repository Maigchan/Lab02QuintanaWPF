using System;
using System.Windows;

namespace WPFLab02Quintana
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, RoutedEventArgs e)
        {
            // Verificar las credenciales del usuario
            string usuario = "quintana";
            string contraseña = "123";

            if (txtUser.Text == usuario && txtPass.Password == contraseña)
            {
                // Las credenciales son válidas, procede a abrir la nueva ventana
                Ventana ventana = new Ventana();
                ventana.Show();
                this.Hide(); // Opcionalmente, puedes ocultar la ventana actual
            }
            else
            {
                // Mostrar un mensaje de error si las credenciales son incorrectas
                MessageBox.Show("Credenciales incorrectas. Por favor, verifica el usuario y la contraseña.", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar la aplicación cuando se hace clic en "Cancelar"
            Application.Current.Shutdown();
        }
    }
}
