using System;
using System.Windows;
//Using agregados
using System.Collections.Generic;
using RegistroAgenda.BLL;
using RegistroAgenda.Entidades;

namespace RegistroAgenda.UI.Consultas
{
    public partial class cEventos : Window
    {
        public cEventos()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Eventos>();
            var listado2 = new List<Contactos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {

                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            listado2 = ContactosBLL.GetList(c => c.ContactoId == Utilidades.ToInt(CriterioTextBox.Text));
                            listado = EventosBLL.GetList(e => e.EventoId == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido para aplicar este filtro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                }
            }
            else
            {
                //MessageBox.Show("Has dejado el Campo (Criterio) vacio.\n\nPor lo tanto, se mostrarán todos los Estudiantes", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                listado = EventosBLL.GetList(c => true);
                listado2 = ContactosBLL.GetList(c => true);
            }

            if (DesdeDatePicker.SelectedDate != null)
                listado = EventosBLL.GetList(c => c.FechaInicio.Date >= DesdeDatePicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = EventosBLL.GetList(c => c.FechaInicio.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
            DatosDataGrid.ItemsSource = listado2;
        }
    }
}