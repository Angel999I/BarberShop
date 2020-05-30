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
using System.Windows.Shapes;

namespace BarberShop
{
    /// <summary>
    /// Interaction logic for AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Window
    {
        Controller controller = new Controller();
        Supplier s;
        bool isEdit;
        public AddSupplier()
        {
            InitializeComponent();
            isEdit = false;
        }

        public AddSupplier(Supplier s)
        {
            InitializeComponent();
            isEdit = true;
            this.s = s;
            UpdateSupplierInfo();
        }

        private void UpdateSupplierInfo()
        {
            NameTextBox.Text = s.name;
            AddressTextBox.Text = s.address;
            PhoneTextBox.Text = s.phone;
            EmailTextBox.Text = s.email;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                string address = AddressTextBox.Text;
                string phone = PhoneTextBox.Text;
                string email = EmailTextBox.Text;

                if (!isEdit)
                    controller.AddSupplier(name, address, phone, email);
                else
                {
                    s.name = name;
                    s.address = address;
                    s.phone = phone;
                    s.email = email;
                    controller.EditSupplier(s);
                }

                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
