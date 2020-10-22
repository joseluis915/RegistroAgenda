using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        }

        private void rEventoMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cContactoMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cEventoMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InformacionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Creado por:\t\t{CreadoPorLabel.Content}\n\nVersión:\t\t\t{VersionLabel.Content}\n\nCreación:\t\t{CreacionLabel.Content}\n\nUltima Modificación:\t{ModificacionLabel.Content}\n\nPara más información:\tjose_burgos3@ucne.edu.do","Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
