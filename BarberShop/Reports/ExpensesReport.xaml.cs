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
    /// Interaction logic for ExpensesReport.xaml
    /// </summary>
    public partial class ExpensesReport : Window
    {
        Controller controller = new Controller();
        public ExpensesReport()
        {
            InitializeComponent();
            UpdateDataGrid(null, null);
        }

        private void UpdateDataGrid(object sender, SelectionChangedEventArgs e)
        {
            if (DatePicker.SelectedDate == null)
            {
                OrderDataGrid.ItemsSource = controller.GetSupplierOrders();
                AdditionalExpenseDataGrid.ItemsSource = controller.GetAdditionalCosts();
                WorkerHoursDataGrid.ItemsSource = controller.GetWorkerHours();
            }
            else
            {
                OrderDataGrid.ItemsSource = controller.GetSupplierOrders().FindAll(x=> DateTime.Compare(x.date, (DateTime)DatePicker.SelectedDate) >= 0);
                AdditionalExpenseDataGrid.ItemsSource = controller.GetAdditionalCosts().FindAll(x => DateTime.Compare(x.date, (DateTime)DatePicker.SelectedDate) >= 0);
                WorkerHoursDataGrid.ItemsSource = controller.GetWorkerHours().FindAll(x => DateTime.Compare(x.date, (DateTime)DatePicker.SelectedDate) >= 0);
            }

            List<WorkerHour> l1 = (List<WorkerHour>)WorkerHoursDataGrid.ItemsSource;
            List<AdditionalCost> l2 = (List<AdditionalCost>)AdditionalExpenseDataGrid.ItemsSource;
            List<SupplierOrder> l3 = (List<SupplierOrder>)OrderDataGrid.ItemsSource;

            TotalCost.Content = "Total Cost: " + (l1.Sum(x => x.total) + l2.Sum(x => x.cost) + l3.Sum(x => x.price)).ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
