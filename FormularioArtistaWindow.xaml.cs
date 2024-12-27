using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProyectoFestival
{
    public partial class FormularioArtistaWindow : Window
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Pais { get; set; }
        public string TipoMusica { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; } // Ruta de la foto seleccionada

        public FormularioArtistaWindow()
        {
            InitializeComponent();
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            Nombre = TxtNombre.Text;
            Genero = TxtGenero.Text;
            Pais = TxtPais.Text;
            TipoMusica = TxtTipoMusica.Text;
            Descripcion = TxtDescripcion.Text;

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Genero) || string.IsNullOrEmpty(Pais) ||
                string.IsNullOrEmpty(TipoMusica) || string.IsNullOrEmpty(Descripcion))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void SeleccionarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png",
                Title = "Seleccionar una Foto"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Foto = openFileDialog.FileName;

                BitmapImage image = new BitmapImage(new Uri(Foto));
                ImgFoto.Source = image;
                ImgFoto.Visibility = Visibility.Visible;
            }
        }

        // Implementación de los métodos GotFocus y LostFocus
        private void TxtNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderNombre.Visibility = Visibility.Hidden;
        }

        private void TxtNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderNombre.Visibility = string.IsNullOrEmpty(TxtNombre.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void TxtGenero_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderGenero.Visibility = Visibility.Hidden;
        }

        private void TxtGenero_LostFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderGenero.Visibility = string.IsNullOrEmpty(TxtGenero.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void TxtPais_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderPais.Visibility = Visibility.Hidden;
        }

        private void TxtPais_LostFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderPais.Visibility = string.IsNullOrEmpty(TxtPais.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void TxtTipoMusica_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderTipoMusica.Visibility = Visibility.Hidden;
        }

        private void TxtTipoMusica_LostFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderTipoMusica.Visibility = string.IsNullOrEmpty(TxtTipoMusica.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void TxtDescripcion_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderDescripcion.Visibility = Visibility.Hidden;
        }

        private void TxtDescripcion_LostFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderDescripcion.Visibility = string.IsNullOrEmpty(TxtDescripcion.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
