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
    /// Interaction logic for CustomerHistory.xaml
    /// </summary>
    public partial class CustomerHistory : Window
    {
        Controller controller = new Controller();
        public CustomerHistory()
        {
            InitializeComponent();
            UpdateComboBox();
        }

        private void UpdateDataGrids()
        {
            List<TimeTable> l1 = controller.GetTimeTable();
            List<Order> l2 = controller.GetOrders();
            if (DatePicker.SelectedDate != null)
            {
                l1 = l1.FindAll(x => DateTime.Compare(x.date, (DateTime)DatePicker.SelectedDate) >= 0);
                l2 = l2.FindAll(x => DateTime.Compare(x.date, (DateTime)DatePicker.SelectedDate) >= 0);
            }
            HaircutDataGrid.ItemsSource = l1.FindAll(x => x.customer_id == ((Customer)CustomerPicker.SelectedItem).Id);
            OrderDataGrid.ItemsSource = l2.FindAll(x => x.customer_id == ((Customer)CustomerPicker.SelectedItem).Id);
        }

        private void UpdateComboBox()
        {
            CustomerPicker.ItemsSource = controller.GetCustomers();
            CustomerPicker.DisplayMemberPath = "name";
        }

        private void CustomerPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerPicker.SelectedIndex > -1)
            {
                UpdateDataGrids();
                DatePicker.IsEnabled = true;
            }
            else
            {
                OrderDataGrid.ItemsSource = null;
                HaircutDataGrid.ItemsSource = null;
                DatePicker.IsEnabled = false;
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataGrids();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
