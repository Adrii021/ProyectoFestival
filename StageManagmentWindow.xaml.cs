using System.Collections.ObjectModel;
using System.Windows;

namespace ProyectoFestival
{
    public partial class StageManagementWindow : Window
    {
        private MainWindow mainWindow; // Referencia a la ventana principal
        public ObservableCollection<Escenario> Escenarios { get; set; }

        public StageManagementWindow(MainWindow previousWindow)
        {
            InitializeComponent();
            mainWindow = previousWindow;
            Escenarios = new ObservableCollection<Escenario>();
            DataGridEscenarios.ItemsSource = Escenarios; // Enlazar los datos al DataGrid
        }

        private void AgregarEscenario_Click(object sender, RoutedEventArgs e)
        {
            // Abrir el formulario para agregar escenarios
            FormularioEscenarioWindow formularioWindow = new FormularioEscenarioWindow();
            if (formularioWindow.ShowDialog() == true)
            {
                Escenarios.Add(new Escenario
                {
                    Nombre = formularioWindow.Nombre,
                    Capacidad = formularioWindow.Capacidad,
                    Ubicacion = formularioWindow.Ubicacion
                });
            }
        }

        private void EditarEscenario_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEscenarios.SelectedItem == null)
            {
                // Mostrar un mensaje de error si no hay un escenario seleccionado
                MessageBox.Show("Por favor, selecciona un escenario para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Obtener el escenario seleccionado
            if (DataGridEscenarios.SelectedItem is Escenario escenarioSeleccionado)
            {
                // Abrir el formulario de edición con los datos actuales del escenario
                FormularioEscenarioWindow formularioWindow = new FormularioEscenarioWindow
                {
                    Nombre = escenarioSeleccionado.Nombre,
                    Capacidad = escenarioSeleccionado.Capacidad,
                    Ubicacion = escenarioSeleccionado.Ubicacion
                };

                if (formularioWindow.ShowDialog() == true)
                {
                    // Actualizar el escenario con los nuevos datos
                    escenarioSeleccionado.Nombre = formularioWindow.Nombre;
                    escenarioSeleccionado.Capacidad = formularioWindow.Capacidad;
                    escenarioSeleccionado.Ubicacion = formularioWindow.Ubicacion;

                    // Refrescar el DataGrid para mostrar los cambios
                    DataGridEscenarios.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un escenario para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarEscenario_Click(object sender, RoutedEventArgs e)
        {
            // Validar si hay un escenario seleccionado en el DataGrid
            if (DataGridEscenarios.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un escenario para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Obtener el escenario seleccionado
            if (DataGridEscenarios.SelectedItem is Escenario escenarioSeleccionado)
            {
                // Confirmar la eliminación
                MessageBoxResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar el escenario '{escenarioSeleccionado.Nombre}'?",
                                                              "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (resultado == MessageBoxResult.Yes)
                {
                    // Eliminar el escenario de la lista
                    Escenarios.Remove(escenarioSeleccionado);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un escenario para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }
    }

    
}
