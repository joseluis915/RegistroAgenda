using System;
using System.Windows;
using RegistroAgenda.BLL;
using RegistroAgenda.Entidades;

namespace RegistroAgenda.UI.Registros
{
    public partial class rEventos : Window
    {
        private Eventos eventos = new Eventos();
        public rEventos()
        {
            InitializeComponent();
            this.DataContext = eventos;

            //——————————————————————————[ VALORES DEL ComboBox Contacto]——————————————————————————
            ContactoIdComboBox.ItemsSource = ContactosBLL.GetContactos();
            ContactoIdComboBox.SelectedValuePath = "ContactoId";
            ContactoIdComboBox.DisplayMemberPath = "NickName";
        }
        //—————————————————————————————————————————————————————[ CARGAR ]—————————————————————————————————————————————————————
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = eventos;
        }
        //—————————————————————————————————————————————————————[ LIMPIAR ]—————————————————————————————————————————————————————
        private void Limpiar()
        {
            this.eventos = new Eventos();
            this.DataContext = eventos;
        }
        //—————————————————————————————————————————————————————[ Validar ]—————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (EventoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return Validado;
        }
        //—————————————————————————————————————————————————————[ BUSCAR ]—————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Eventos encontrado = EventosBLL.Buscar(eventos.EventoId);

            if (encontrado != null)
            {
                eventos = encontrado;
                Cargar();
            }
            else
            {
                MessageBox.Show($"Este pedido no fue encontrado.\n\nAsegurese que existe o cree uno nuevo.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                EventoIdTextBox.Clear();
                EventoIdTextBox.Focus();
            }
        }
        //—————————————————————————————————————————————————————[ AGREGAR FILA ]—————————————————————————————————————————————————————
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContactoIdComboBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Contacto Id) está vacío.\n\nPorfavor, Seleccione un Contacto.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ContactoIdComboBox.IsDropDownOpen = true;
                return;
            }

            if (TipoEventoTextBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Tipo Evento) está vacio.\n\nPorfavor, Describa el tipo de evento que se realizará.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                TipoEventoTextBox.Focus();
                return;
            }

            if (NombreEventoTextBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Nombre Evento) está vacio.\n\nAsigne un nombre al evento.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreEventoTextBox.Focus();
                return;
            }

            if (LugarTextBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Lugar) está vacio.\n\nAsigne un lugar al evento.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                LugarTextBox.Focus();
                return;
            }

            var filaDetalle = new EventosDetalle
            {
                EventoId = this.eventos.EventoId,
                ContactoId = Convert.ToInt32(ContactoIdComboBox.SelectedValue.ToString()),
                contactos = (Contactos)ContactoIdComboBox.SelectedItem,
                TipoEvento = Convert.ToString(TipoEventoTextBox.Text),
                NombreEvento = Convert.ToString(NombreEventoTextBox.Text),
                Lugar = Convert.ToString(LugarTextBox.Text)
            };

            this.eventos.Detalle.Add(filaDetalle);
            Cargar();

            ContactoIdComboBox.SelectedIndex = -1;

            TipoEventoTextBox.Clear();
            NombreEventoTextBox.Clear();
            LugarTextBox.Clear();

            ContactoIdComboBox.IsDropDownOpen = true;
        }
        //—————————————————————————————————————————————————————[ REMOVER FILA ]—————————————————————————————————————————————————————
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                eventos.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
        //—————————————————————————————————————————————————————[ NUEVO ]—————————————————————————————————————————————————————
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //—————————————————————————————————————————————————————[ GUARDAR ]—————————————————————————————————————————————————————
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = EventosBLL.Guardar(this.eventos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //—————————————————————————————————————————————————————[ ELIMINAR ]—————————————————————————————————————————————————————
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (EventosBLL.Eliminar(Utilidades.ToInt(EventoIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
