using System.Windows;
using RegistroAgenda.UI.Consultas;
using RegistroAgenda.UI.Registros;

namespace RegistroAgenda
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rContactoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rContactos rContactos = new rContactos();
            rContactos.Show();
        }

        private void rEventoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEventos rEventos = new rEventos();
            rEventos.Show();
        }

        private void cEventoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cEventos cEventos = new cEventos();
            cEventos.Show();
        }

        private void InformacionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Creado por:\t\t{CreadoPorLabel.Content}\n\nVersión:\t\t\t{VersionLabel.Content}\n\nCreación:\t\t{CreacionLabel.Content}\n\nUltima Modificación:\t{ModificacionLabel.Content}\n\nPara más información:\tjose_burgos3@ucne.edu.do","Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
