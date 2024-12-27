using System.Windows;
using System.Windows.Controls;

namespace ProyectoFestival
{
    public partial class FormularioFestivalWindow : Window
    {
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Lugar { get; set; }

        public FormularioFestivalWindow()
        {
            InitializeComponent();
        }

        private void TxtNombre_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "Nombre del Festival")
            {
                ((TextBox)sender).Text = string.Empty;
                ((TextBox)sender).Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void TxtNombre_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "Nombre del Festival";
                ((TextBox)sender).Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void TxtFecha_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "Fecha del Festival (dd/mm/yyyy)")
            {
                ((TextBox)sender).Text = string.Empty;
                ((TextBox)sender).Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void TxtFecha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "Fecha del Festival (dd/mm/yyyy)";
                ((TextBox)sender).Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void TxtLugar_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "Lugar del Festival")
            {
                ((TextBox)sender).Text = string.Empty;
                ((TextBox)sender).Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void TxtLugar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "Lugar del Festival";
                ((TextBox)sender).Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            Nombre = TxtNombre.Text;
            Fecha = TxtFecha.Text;
            Lugar = TxtLugar.Text;

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Fecha) || string.IsNullOrEmpty(Lugar))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}
