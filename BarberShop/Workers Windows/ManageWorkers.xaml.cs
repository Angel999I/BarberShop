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

namespace BarberShop.Workers_Windows
{
    /// <summary>
    /// Interaction logic for ManageWorkers.xaml
    /// </summary>
    public partial class ManageWorkers : Window
    {
        Controller controller = new Controller();
        public ManageWorkers()
        {
            InitializeComponent();
        }

        private void UpdateDataGrid()
        {
            WorkersDataGrid.ItemsSource = controller.GetWorkers();
        }

        private void DeleteWorker_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.DeleteWorker((Worker)WorkersDataGrid.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Unexpected error, please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateDataGrid();
        }

        private void EditWorker_Click(object sender, RoutedEventArgs e)
        {
            Worker w = (Worker)WorkersDataGrid.SelectedItem;
            AddWorker window = new AddWorker(w);
            window.ShowDialog();
            UpdateDataGrid();
        }

        private void NewWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            AddWorker window = new AddWorker();
            window.ShowDialog();
            UpdateDataGrid();
        }
    }
}
