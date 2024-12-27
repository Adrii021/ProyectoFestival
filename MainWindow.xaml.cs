using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoFestival
{
    public partial class MainWindow : Window
    {
        private LoginWindow loginWindow; // Referencia a la ventana de login

        public ObservableCollection<Artista> Artistas { get; set; } = new ObservableCollection<Artista>();
        public ObservableCollection<Escenario> Escenarios { get; set; } = new ObservableCollection<Escenario>();
        public ObservableCollection<Festival> Festivales { get; set; } = new ObservableCollection<Festival>();

        public MainWindow(LoginWindow previousWindow)
        {
            InitializeComponent();
            loginWindow = previousWindow; // Guardamos la referencia de la ventana de login
            DataGridArtistas.ItemsSource = Artistas;
            DataGridEscenarios.ItemsSource = Escenarios;
            DataGridFestivales.ItemsSource = Festivales;
        }

        private void AgregarArtista_Click(object sender, RoutedEventArgs e)
        {
            var formularioWindow = new FormularioArtistaWindow();
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
            }
        }

        private void AgregarEscenario_Click(object sender, RoutedEventArgs e)
        {
            var formularioWindow = new FormularioEscenarioWindow();
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

        private void AgregarFestival_Click(object sender, RoutedEventArgs e)
        {
            var formularioWindow = new FormularioFestivalWindow();
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

        private void EditarArtista_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridArtistas.SelectedItem is Artista seleccionado)
            {
                var formularioWindow = new FormularioArtistaWindow
                {
                    Nombre = seleccionado.Nombre,
                    Genero = seleccionado.Genero,
                    Pais = seleccionado.Pais,
                    TipoMusica = seleccionado.TipoMusica,
                    Descripcion = seleccionado.Descripcion,
                    Foto = seleccionado.Foto
                };

                if (formularioWindow.ShowDialog() == true)
                {
                    seleccionado.Nombre = formularioWindow.Nombre;
                    seleccionado.Genero = formularioWindow.Genero;
                    seleccionado.Pais = formularioWindow.Pais;
                    seleccionado.TipoMusica = formularioWindow.TipoMusica;
                    seleccionado.Descripcion = formularioWindow.Descripcion;
                    seleccionado.Foto = formularioWindow.Foto;
                    DataGridArtistas.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un artista para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditarEscenario_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEscenarios.SelectedItem is Escenario seleccionado)
            {
                var formularioWindow = new FormularioEscenarioWindow
                {
                    Nombre = seleccionado.Nombre,
                    Capacidad = seleccionado.Capacidad,
                    Ubicacion = seleccionado.Ubicacion
                };

                if (formularioWindow.ShowDialog() == true)
                {
                    seleccionado.Nombre = formularioWindow.Nombre;
                    seleccionado.Capacidad = formularioWindow.Capacidad;
                    seleccionado.Ubicacion = formularioWindow.Ubicacion;
                    DataGridEscenarios.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un escenario para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditarFestival_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridFestivales.SelectedItem is Festival seleccionado)
            {
                var formularioWindow = new FormularioFestivalWindow
                {
                    Nombre = seleccionado.Nombre,
                    Fecha = seleccionado.Fecha,
                    Lugar = seleccionado.Lugar
                };

                if (formularioWindow.ShowDialog() == true)
                {
                    seleccionado.Nombre = formularioWindow.Nombre;
                    seleccionado.Fecha = formularioWindow.Fecha;
                    seleccionado.Lugar = formularioWindow.Lugar;
                    DataGridFestivales.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un festival para editar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarArtista_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridArtistas.SelectedItem is Artista seleccionado)
            {
                Artistas.Remove(seleccionado);
            }
            else
            {
                MessageBox.Show("Selecciona un artista para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarEscenario_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridEscenarios.SelectedItem is Escenario seleccionado)
            {
                Escenarios.Remove(seleccionado);
            }
            else
            {
                MessageBox.Show("Selecciona un escenario para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarFestival_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridFestivales.SelectedItem is Festival seleccionado)
            {
                Festivales.Remove(seleccionado);
            }
            else
            {
                MessageBox.Show("Selecciona un festival para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (loginWindow != null)
            {
                loginWindow.Visibility = Visibility.Visible;
            }
            this.Close(); // Cierra la ventana principal
        }
    }

    
}
