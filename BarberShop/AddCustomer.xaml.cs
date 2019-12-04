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
        Controller cont = new Controller();
        private Customer customer;
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public Customer GetCustomer()
        {
            return customer;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                cont.AddCustomer(Name.Text, Address.Text);
                customer = new Customer();

                customer.name = Name.Text;
                customer.address = Address.Text;

                Close();
            }
            catch(ArgumentException a)
            {
                MessageBox.Show("One of the fields is too long, contains illegal characters or empty", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception a)
            {
                MessageBox.Show("Unexpected error: " + a.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }
    }
}
