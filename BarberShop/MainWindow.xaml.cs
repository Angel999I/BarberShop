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
            CmbBoxHaircut.ItemsSource = cont.GetHaircuts();
            CmbBoxHaircut.DisplayMemberPath = "name";

            CmbBoxCustomer.ItemsSource = cont.GetCustomers();
            CmbBoxCustomer.DisplayMemberPath = "name";
        }

        private void UpdateCustomersView()
        {
            CustomersView.ItemsSource = cont.GetCustomers();
        }

        private void UpdateTimeTableView()
        {
            TimeTableSmall.ItemsSource = cont.GetTimeTable();
            TimeTableView.ItemsSource = cont.GetTimeTable();
        }

        private void ClearNew_Click(object sender, RoutedEventArgs e)
        {
            CmbBoxHaircut.SelectedIndex = -1;
            CmbBoxCustomer.SelectedIndex = -1;
            datePicker.SelectedDate = null;
            TxtBoxPriceNew.Text = "";
        }

        private async void NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            //AddCustomer win = new AddCustomer();
            //win.ShowDialog();

            Customer customer = new Customer();

            AddCustomerDialog dialog = new AddCustomerDialog()
            {
                DataContext = customer
            };


            await DialogHost.Show(dialog, (object _, DialogClosingEventArgs args) =>
            {

                if (args.Parameter.GetType() == typeof(bool) && (bool)args.Parameter)
                {
                    try
                    {
                        cont.AddCustomer(customer);
                        UpdateCustomersView();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        args.Cancel();

                        dialog.name.Text = "";
                        dialog.address.Text = "";

                        customer.name = "";
                        customer.address = "";
                    }
                }
            });
        }

        private void DelCustomer_Click(object sender, RoutedEventArgs e)
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


        private void CmbBoxHaircut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbBoxHaircut.SelectedIndex != -1)
            {
                TxtBoxPriceNew.Text = ((Haircut)CmbBoxHaircut.SelectedItem).price.ToString();
            }
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            double money = double.Parse(TxtBoxPriceNew.Text);
            DateTime date = (DateTime)datePicker.SelectedDate;
            int type = ((Haircut)CmbBoxHaircut.SelectedItem).Id;
            int customer = ((Customer)CmbBoxCustomer.SelectedItem).Id;

            cont.AddTimeTable(money, date, type, customer);

            UpdateTimeTableView();
            UpdateComboBox();

            ClearNew_Click(sender, e);
        }

        private void CustomerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Customer> original = cont.GetCustomers();
            List<Customer> result = new List<Customer>();
            string search = CustomerSearch.Text.ToLower();

            if (search == "")
            {
                CustomersView.ItemsSource = original;
                return;
            }

            for (int i = 0; i < original.Count; i++)
            {
                if (original[i].name.ToLower().Contains(search) || original[i].address.ToLower().Contains(search))
                {
                    result.Add(original[i]);
                }
            }

            CustomersView.ItemsSource = result;
        }

        private void TimeTableSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<TimeTable> original = cont.GetTimeTable();
            List<TimeTable> result = new List<TimeTable>();
            string search = TimeTableSearch.Text.ToLower();

            if (search == "")
            {
                TimeTableView.ItemsSource = original;
                return;
            }

            for (int i = 0; i < original.Count; i++)
            {
                if (original[i].Customer.name.ToLower().Contains(search) ||
                    original[i].date.ToShortDateString().ToLower().Contains(search) ||
                    original[i].Haircut.name.ToLower().Contains(search) ||
                    original[i].price.ToString().Contains(search))
                {
                    result.Add(original[i]);
                }
            }

            TimeTableView.ItemsSource = result;
        }
    }
}
