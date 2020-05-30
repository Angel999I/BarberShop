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
    /// Interaction logic for AdditionalExpenses.xaml
    /// </summary>
    public partial class AdditionalExpenses : Window
    {
        Controller controller = new Controller();
        public AdditionalExpenses()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            ExpensesDataGrid.ItemsSource = controller.GetAdditionalCosts();
        }

        private void NewExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            AddAdditionalCost window = new AddAdditionalCost();
            window.ShowDialog();
            UpdateDataGrid();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            AdditionalCost a = (AdditionalCost)ExpensesDataGrid.SelectedItem;
            controller.DeleteAdditionalCosts(a);
            UpdateDataGrid();
        }

        private void EditExpense_Click(object sender, RoutedEventArgs e)
        {
            AdditionalCost a = (AdditionalCost)ExpensesDataGrid.SelectedItem;
            AddAdditionalCost window = new AddAdditionalCost(a);
            window.ShowDialog();
            UpdateDataGrid();
        }
    }
}
