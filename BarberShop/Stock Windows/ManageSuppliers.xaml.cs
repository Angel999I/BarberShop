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
    /// Interaction logic for ManageSuplliers.xaml
    /// </summary>
    public partial class ManageSuppliers : Window
    {
        Controller controller = new Controller();
        public ManageSuppliers()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            SuppliersDataGrid.ItemsSource = controller.GetSuppliers();
        }

        private void NewSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            AddSupplier window = new AddSupplier();
            window.ShowDialog();
            UpdateDataGrid();
        }

        private void DeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.DeleteSupplier((Supplier)SuppliersDataGrid.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Unexpected error, please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateDataGrid();
        }

        private void EditSupplier_Click(object sender, RoutedEventArgs e)
        {
            Supplier s = (Supplier)SuppliersDataGrid.SelectedItem;
            AddSupplier window = new AddSupplier(s);
            window.ShowDialog();
            UpdateDataGrid();
        }
    }
}
