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
    /// Interaction logic for IncomesReport.xaml
    /// </summary>
    public partial class IncomesReport : Window
    {
        Controller controller = new Controller();
        public IncomesReport()
        {
            InitializeComponent();
            UpdateDataGrid(null, null);
        }

        private void UpdateDataGrid(object sender, SelectionChangedEventArgs e)
        {
            if (DatePicker.SelectedDate == null)
            {
                BookDataGrid.ItemsSource = controller.GetTimeTable();
                OrderDataGrid.ItemsSource = controller.GetOrders();
            }
            else
            {
                BookDataGrid.ItemsSource = controller.GetTimeTable().FindAll(x => DateTime.Compare(x.date, (DateTime)DatePicker.SelectedDate) >= 0);
                OrderDataGrid.ItemsSource = controller.GetOrders().FindAll(x => DateTime.Compare(x.date, (DateTime)DatePicker.SelectedDate) >= 0);
            }

            TotalCost.Content = "Income: " + (((List<TimeTable>)BookDataGrid.ItemsSource).Sum(x => x.price) + ((List<Order>)OrderDataGrid.ItemsSource).Sum(x => x.price)).ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
