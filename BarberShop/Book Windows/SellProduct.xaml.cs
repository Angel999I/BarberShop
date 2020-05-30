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
    /// Interaction logic for SellProduct.xaml
    /// </summary>
    public partial class SellProduct : Window
    {
        Controller controller = new Controller();
        public SellProduct()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            controller = null;
            controller = new Controller();
            OrdersDataGrid.ItemsSource = null;
            OrdersDataGrid.ItemsSource = controller.GetOrders();
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrdersDataGrid.SelectedItem;
            controller.DeleteOrder(o);
            UpdateDataGrid();
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            Order o = (Order)OrdersDataGrid.SelectedItem;
            AddOrderCustomer window = new AddOrderCustomer(o);
            window.ShowDialog();
            UpdateDataGrid();
        }

        private void NewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            AddOrderCustomer window = new AddOrderCustomer();
            window.ShowDialog();
            UpdateDataGrid();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
