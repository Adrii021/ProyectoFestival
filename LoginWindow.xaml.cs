using System.Windows;
using System.Windows.Input;

namespace ProyectoFestival
{
    public partial class LoginWindow : Window
    {
        private MainWindow previousWindow; // Referencia a una ventana previa, si aplica

        public LoginWindow(MainWindow mainWindow = null)
        {
            InitializeComponent();
            previousWindow = mainWindow; // Guardamos referencia de la ventana anterior, si existe
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            if (previousWindow != null)
            {
                previousWindow.Visibility = Visibility.Visible; // Mostramos la ventana anterior
            }
            this.Close(); // Cerramos la ventana de login
        }

        private void Acceder_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Password.Trim();

            if (usuario == "admin" && contrasena == "ipo1")
            {
                // Crea la ventana principal y oculta la ventana de login
                MainWindow mainMenu = new MainWindow(this);
                mainMenu.Show();
                this.Visibility = Visibility.Hidden; // Oculta la ventana actual
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            // Si se presiona Enter, mover el foco al cuadro de contraseña
            if (e.Key == Key.Enter)
            {
                txtContrasena.Focus();
            }
        }

        private void TxtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            // Si se presiona Enter, ejecutar la acción del botón Acceder
            if (e.Key == Key.Enter)
            {
                Acceder_Click(sender, e);
            }
        }
    }
}
