using System.Windows;

namespace ProyectoFestival
{
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void Acceso_Click(object sender, RoutedEventArgs e)
        {
            // Abre la ventana de inicio de sesión
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close(); // Cierra la ventana de bienvenida
        }
    }
}
