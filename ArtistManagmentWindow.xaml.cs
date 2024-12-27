using System.Collections.ObjectModel;
using System.Windows;

namespace ProyectoFestival
{
    public partial class ArtistManagementWindow : Window
    {
        private MainWindow mainWindow;
        public ObservableCollection<Artista> Artistas { get; set; }

        public ArtistManagementWindow(MainWindow previousWindow)
        {
            InitializeComponent();
            mainWindow = previousWindow;
            Artistas = new ObservableCollection<Artista>();
            DataGridArtistas.ItemsSource = Artistas;
        }

        private void AgregarArtista_Click(object sender, RoutedEventArgs e)
        {
            FormularioArtistaWindow formularioWindow = new FormularioArtistaWindow();
            if (formularioWindow.ShowDialog() == true)
            {
                Artistas.Add(new Artista
                {
                    Nombre = formularioWindow.Nombre,
                    Genero = formularioWindow.Genero,
                    Pais = formularioWindow.Pais,
                    TipoMusica = formularioWindow.TipoMusica,
                    Descripcion = formularioWindow.Descripcion,
                    Foto = formularioWindow.Foto
                });
                DataGridArtistas.Items.Refresh();
            }
        }

        private void EditarArtista_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si hay un elemento seleccionado en el DataGrid
            if (DataGridArtistas.SelectedItem == null)
            {
                // Mostrar un mensaje de error si no hay un artista seleccionado
                MessageBox.Show("Por favor, selecciona un artista para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Intentar convertir el objeto seleccionado al tipo Artista
            if (DataGridArtistas.SelectedItem is Artista artistaSeleccionado)
            {
                // Abrir el formulario de edición con los datos actuales del artista
                FormularioArtistaWindow formularioWindow = new FormularioArtistaWindow
                {
                    Nombre = artistaSeleccionado.Nombre,
                    Genero = artistaSeleccionado.Genero,
                    Pais = artistaSeleccionado.Pais,
                    TipoMusica = artistaSeleccionado.TipoMusica,
                    Descripcion = artistaSeleccionado.Descripcion,
                    Foto = artistaSeleccionado.Foto
                };

                if (formularioWindow.ShowDialog() == true)
                {
                    // Actualizar el artista con los nuevos datos
                    artistaSeleccionado.Nombre = formularioWindow.Nombre;
                    artistaSeleccionado.Genero = formularioWindow.Genero;
                    artistaSeleccionado.Pais = formularioWindow.Pais;
                    artistaSeleccionado.TipoMusica = formularioWindow.TipoMusica;
                    artistaSeleccionado.Descripcion = formularioWindow.Descripcion;
                    artistaSeleccionado.Foto = formularioWindow.Foto;

                    // Refrescar el DataGrid para mostrar los cambios
                    DataGridArtistas.Items.Refresh();
                }
            }
            else
            {
                // Mostrar un mensaje de error si el objeto no es del tipo esperado
                MessageBox.Show("El elemento seleccionado no es válido. Por favor, intenta de nuevo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void EliminarArtista_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si hay un elemento seleccionado en el DataGrid
            if (DataGridArtistas.SelectedItem == null)
            {
                // Mostrar un mensaje de error si no hay un artista seleccionado
                MessageBox.Show("Por favor, selecciona un artista para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Intentar convertir el objeto seleccionado al tipo Artista
            if (DataGridArtistas.SelectedItem is Artista artistaSeleccionado)
            {
                // Confirmar la eliminación
                MessageBoxResult resultado = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar al artista '{artistaSeleccionado.Nombre}'?",
                    "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (resultado == MessageBoxResult.Yes)
                {
                    // Eliminar el artista de la colección
                    Artistas.Remove(artistaSeleccionado);

                    // Refrescar el DataGrid para reflejar los cambios
                    DataGridArtistas.Items.Refresh();

                    MessageBox.Show($"Artista '{artistaSeleccionado.Nombre}' eliminado correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                // Mostrar un mensaje de error si el objeto no es del tipo esperado
                MessageBox.Show("El elemento seleccionado no es válido. Por favor, intenta de nuevo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }
    }

   
}
