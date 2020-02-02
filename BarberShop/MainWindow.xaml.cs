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
        Customer customerNew;

        Controller cont = new Controller();
        public MainWindow()
        {
            InitializeComponent();

            UpdateCustomersView();
            UpdateTimeTableView();
            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            cmbBoxHaircut.ItemsSource = cont.GetHaircuts();
            cmbBoxHaircut.DisplayMemberPath = "name";

            cmbBoxCustomer.ItemsSource = cont.GetCustomers();
            cmbBoxCustomer.DisplayMemberPath = "name";
        }

        private void UpdateCustomersView()
        {
            CustomersView.ItemsSource = cont.GetCustomers();
        }

        private void UpdateTimeTableView()
        {
            TimeTableSmall.ItemsSource = cont.GetTimeTable();
            TimeTable.ItemsSource = cont.GetTimeTable();
        }

        private void ClearNew_Click(object sender, RoutedEventArgs e)
        {
            cmbBoxHaircut.SelectedIndex = -1;
            TxtBoxPriceNew.Text = "";
        }

        private void NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer win = new AddCustomer();
            win.ShowDialog();
            UpdateCustomersView();
            UpdateComboBox();
            customerNew = win.GetCustomer();
        }

        private void DelCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cont.DeleteCustomer((Customer)CustomersView.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Unexpected error, please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateCustomersView();
        }

        private void cmbBoxHaircut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBoxHaircut.SelectedIndex != -1)
            {
                TxtBoxPriceNew.Text = ((Haircut)cmbBoxHaircut.SelectedItem).price.ToString();
            }
        }

        private void btnFindCustomer_Click(object sender, RoutedEventArgs e)
        {
            FindCustomer win = new FindCustomer();
            win.ShowDialog();
            UpdateCustomersView();
            customerNew = win.GetCustomer();

        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            double money = double.Parse(TxtBoxPriceNew.Text);
            DateTime date = (DateTime)datePicker.SelectedDate;
            int type = ((Haircut)cmbBoxHaircut.SelectedItem).Id;
            int customer = ((Customer)cmbBoxCustomer.SelectedItem).Id;

            cont.AddTimeTable(money, date, type, customer);

            UpdateTimeTableView();
            UpdateComboBox();
        }
    }
}
