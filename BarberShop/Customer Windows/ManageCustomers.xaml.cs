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
    /// Interaction logic for ManageCustomers.xaml
    /// </summary>
    public partial class ManageCustomers : Window
    {
        Controller controller = new Controller();
        public ManageCustomers()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            CustomersDataGrid.ItemsSource = controller.GetCustomers();
        }

        private void NewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer window = new AddCustomer();
            window.ShowDialog();
            UpdateDataGrid();
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer c = (Customer)CustomersDataGrid.SelectedItem;
            AddCustomer window = new AddCustomer();
            window.ShowDialog();
            UpdateDataGrid();
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.DeleteCustomer((Customer)CustomersDataGrid.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Unexpected error, please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateDataGrid();
        }
    }
}
