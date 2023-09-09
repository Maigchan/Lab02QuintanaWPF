using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFLab02Quintana
{
    public partial class Ventana : Window
    {
        private List<Usuario> usuarios; // Mover la lista al ámbito de la clase

        public Ventana()
        {
            InitializeComponent();

            // Crear una lista de datos de prueba
            usuarios = new List<Usuario>
            {
                new Usuario { NombreUsuario = "Usuario1", Planta = "Planta 1" },
                new Usuario { NombreUsuario = "Usuario2", Planta = "Planta 2" },
                new Usuario { NombreUsuario = "Usuario3", Planta = "Planta 1" },
                new Usuario { NombreUsuario = "Usuario4", Planta = "Planta 3" },
            };

            // Asignar la lista al DataGrid como fuente de datos
            dataGrid.ItemsSource = usuarios;
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            // Obtén los valores seleccionados en el ComboBox y el campo de entrada de Usuario
            string plantaSeleccionada = (cmbPlanta.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string usuarioFiltrado = txtUsuario.Text;


            // Aplica el filtro a la lista de usuarios
            List<Usuario> usuariosFiltrados = usuarios;

            if (!string.IsNullOrEmpty(plantaSeleccionada))
            {
                usuariosFiltrados = usuariosFiltrados.Where(u => u.Planta == plantaSeleccionada).ToList();
            }

            if (!string.IsNullOrEmpty(usuarioFiltrado))
            {
                usuariosFiltrados = usuariosFiltrados.Where(u => u.NombreUsuario.Contains(usuarioFiltrado)).ToList();
            }

            // Actualiza la fuente de datos del DataGrid con los usuarios filtrados
            dataGrid.ItemsSource = usuariosFiltrados;
        }
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            // Limpiar el ComboBox y el TextBox
            cmbPlanta.SelectedItem = null;
            txtUsuario.Text = string.Empty;

            // Restaurar la lista completa de usuarios en el DataGrid
            dataGrid.ItemsSource = usuarios;
        }

    }

    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string Planta { get; set; }
    }
}
