using System.Collections.ObjectModel;
using System.Windows;

namespace ProyectoFestival
{
    public partial class FestivalManagementWindow : Window
    {
        private MainWindow mainWindow; // Referencia a la ventana principal
        public ObservableCollection<Festival> Festivales { get; set; }

        public FestivalManagementWindow(MainWindow previousWindow)
        {
            InitializeComponent();
            mainWindow = previousWindow;
            Festivales = new ObservableCollection<Festival>();
            DataGridFestivales.ItemsSource = Festivales; // Enlazar los datos al DataGrid
        }

        private void AgregarFestival_Click(object sender, RoutedEventArgs e)
        {
            // Abrir el formulario para agregar festivales
            FormularioFestivalWindow formularioWindow = new FormularioFestivalWindow();
            if (formularioWindow.ShowDialog() == true)
            {
                Festivales.Add(new Festival
                {
                    Nombre = formularioWindow.Nombre,
                    Fecha = formularioWindow.Fecha,
                    Lugar = formularioWindow.Lugar
                });
            }
        }

        private void EditarFestival_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridFestivales.SelectedItem == null)
            {
                // Mostrar un mensaje de error si no hay un festival seleccionado
                MessageBox.Show("Por favor, selecciona un festival para editarlo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Obtener el festival seleccionado
            if (DataGridFestivales.SelectedItem is Festival festivalSeleccionado)
            {
                // Abrir el formulario de edición con los datos actuales del festival
                FormularioFestivalWindow formularioWindow = new FormularioFestivalWindow
                {
                    Nombre = festivalSeleccionado.Nombre,
                    Fecha = festivalSeleccionado.Fecha,
                    Lugar = festivalSeleccionado.Lugar
                };

                if (formularioWindow.ShowDialog() == true)
                {
                    // Actualizar el festival con los nuevos datos
                    festivalSeleccionado.Nombre = formularioWindow.Nombre;
                    festivalSeleccionado.Fecha = formularioWindow.Fecha;
                    festivalSeleccionado.Lugar = formularioWindow.Lugar;

                    // Refrescar el DataGrid para mostrar los cambios
                    DataGridFestivales.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un festival para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarFestival_Click(object sender, RoutedEventArgs e)
        {
            // Validar si hay un festival seleccionado en el DataGrid
            if (DataGridFestivales.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un festival para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Obtener el festival seleccionado
            if (DataGridFestivales.SelectedItem is Festival festivalSeleccionado)
            {
                // Confirmar la eliminación
                MessageBoxResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar el festival '{festivalSeleccionado.Nombre}'?",
                                                              "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (resultado == MessageBoxResult.Yes)
                {
                    // Eliminar el festival de la lista
                    Festivales.Remove(festivalSeleccionado);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un festival para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }
    }

  
}
