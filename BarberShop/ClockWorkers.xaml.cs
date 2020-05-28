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
    /// Interaction logic for ClockWorkers.xaml
    /// </summary>
    public partial class ClockWorkers : Window
    {
        Controller controller = new Controller();
        public ClockWorkers()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            ClockWorkersDataGrid.ItemsSource = controller.GetWorkerHours();
        }

        private void NewClockWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            AddClockHours window = new AddClockHours();
            window.ShowDialog();
            UpdateDataGrid();
        }

        private void DeleteWorkerHour_Click(object sender, RoutedEventArgs e)
        {
            WorkerHour w = (WorkerHour)ClockWorkersDataGrid.SelectedItem;
            controller.DeleteWorkerHour(w);
            UpdateDataGrid();
        }

        private void EditWorkerHour_Click(object sender, RoutedEventArgs e)
        {
            WorkerHour w = (WorkerHour)ClockWorkersDataGrid.SelectedItem;
            AddClockHours window = new AddClockHours(w);
            window.ShowDialog();
            UpdateDataGrid();
        }
    }
}
