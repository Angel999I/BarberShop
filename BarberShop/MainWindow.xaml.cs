using BarberShop.Workers_Windows;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarberShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public MainWindow()
        {
            ManageTimeTable window = new ManageTimeTable();
            window.Close();
            InitializeComponent();
        }

        private void ManageTimeTable_Click(object sender, RoutedEventArgs e)
        {
            ManageTimeTable window = new ManageTimeTable();
            window.ShowDialog();
        }

        private void ManageSuppliers_Click(object sender, RoutedEventArgs e)
        {
            ManageSuppliers window = new ManageSuppliers();
            window.ShowDialog();
        }

        private void ManageWorkers_Click(object sender, RoutedEventArgs e)
        {
            ManageWorkers window = new ManageWorkers();
            window.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ManageCustomers_Click(object sender, RoutedEventArgs e)
        {
            ManageCustomers window = new ManageCustomers();
            window.ShowDialog();
        }

        private void ManageProductList_Click(object sender, RoutedEventArgs e)
        {
            ManageProductsList window = new ManageProductsList();
            window.ShowDialog();
        }

        private void ClockWorkers_Click(object sender, RoutedEventArgs e)
        {
            ClockWorkers window = new ClockWorkers();
            window.ShowDialog();
        }
        private void OrderProducts_Click(object sender, RoutedEventArgs e)
        {
            OrderProducts window = new OrderProducts();
            window.ShowDialog();
        }

        private void SellProducts_Click(object sender, RoutedEventArgs e)
        {
            SellProduct window = new SellProduct();
            window.ShowDialog();
        }

        private void CustomerHistory_Click(object sender, RoutedEventArgs e)
        {
            CustomerHistory window = new CustomerHistory();
            window.ShowDialog();
        }
        private void ReportAdditionalExpenses(object sender, RoutedEventArgs e)
        {
            AdditionalExpenses window = new AdditionalExpenses();
            window.ShowDialog();
        }

        private void ExpensesReport_Click(object sender, RoutedEventArgs e)
        {
            ExpensesReport window = new ExpensesReport();
            window.ShowDialog();
        }

        private void IncomeReport_Click(object sender, RoutedEventArgs e)
        {
            IncomesReport window = new IncomesReport();
            window.ShowDialog();
        }

        private void DialogHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Center_Click(object sender, RoutedEventArgs e)
        {
            Rect workArea = System.Windows.SystemParameters.WorkArea;
            this.Left = (workArea.Width - this.Width) / 2 + workArea.Left;
            this.Top = (workArea.Height - this.Height) / 2 + workArea.Top;
        }
    }
}
