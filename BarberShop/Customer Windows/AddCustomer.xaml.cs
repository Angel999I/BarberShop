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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        Controller controller = new Controller();
        Customer c;
        bool isEdit;
        public AddCustomer()
        {
            InitializeComponent();
            isEdit = false;
        }

        public AddCustomer(Customer c)
        {
            InitializeComponent();
            this.c = c;
            isEdit = true;
            UpdateCustomerInfo();
        }

        public void UpdateCustomerInfo()
        {
            NameTextBox.Text = c.name;
            AddressTextBox.Text = c.address;
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

                if (!isEdit)
                    controller.AddCustomer(name, address);
                else
                {
                    c.name = name;
                    c.address = address;

                    controller.EditCustomer(c);
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
