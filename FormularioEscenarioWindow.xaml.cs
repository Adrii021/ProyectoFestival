using System.Windows;

namespace ProyectoFestival
{
    public partial class FormularioEscenarioWindow : Window
    {
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Ubicacion { get; set; }

        public FormularioEscenarioWindow()
        {
            InitializeComponent();
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            Nombre = TxtNombre.Text;
            if (!int.TryParse(TxtCapacidad.Text, out int capacidad))
            {
                MessageBox.Show("Por favor, introduce un valor numérico para la capacidad.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Capacidad = capacidad;
            Ubicacion = TxtUbicacion.Text;

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Ubicacion))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void TxtNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderNombre.Visibility = Visibility.Hidden;
        }

        private void TxtNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderNombre.Visibility = string.IsNullOrEmpty(TxtNombre.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void TxtCapacidad_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderCapacidad.Visibility = Visibility.Hidden;
        }

        private void TxtCapacidad_LostFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderCapacidad.Visibility = string.IsNullOrEmpty(TxtCapacidad.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void TxtUbicacion_GotFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderUbicacion.Visibility = Visibility.Hidden;
        }

        private void TxtUbicacion_LostFocus(object sender, RoutedEventArgs e)
        {
            PlaceholderUbicacion.Visibility = string.IsNullOrEmpty(TxtUbicacion.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
