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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BarberShop
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        Controller controller = new Controller();
        TimeTable t;
        bool isEdit;
        public AddBook()
        {
            InitializeComponent();
            SetComboBox();
            isEdit = false;
        }

        public AddBook(TimeTable t)
        {
            InitializeComponent();
            SetComboBox();
            isEdit = true;
            this.t = t;
            UpdateBookInfo();
        }

        private void UpdateBookInfo()
        {
            List<Customer> l1 = (List<Customer>)CustomerPicker.ItemsSource;
            List<Haircut> l2 = (List<Haircut>)HaircutPicker.ItemsSource;
            //MessageBox.Show(l1.FindIndex(x => x == t.Customer).ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            DatePicker.SelectedDate = t.date;
            TimePicker.Text = t.time.ToString();
            CustomerPicker.SelectedIndex = l1.FindIndex(x => x.Id == t.Customer.Id);
            HaircutPicker.SelectedIndex = l2.FindIndex(x => x.Id == t.Haircut.Id);
            PriceTextBox.Text = t.price.ToString();
        }

        private void SetComboBox()
        {
            CustomerPicker.ItemsSource = controller.GetCustomers();
            CustomerPicker.DisplayMemberPath = "name";

            HaircutPicker.ItemsSource = controller.GetHaircuts();
            HaircutPicker.DisplayMemberPath = "name";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            double price = double.Parse(PriceTextBox.Text);
            TimeSpan time = TimeSpan.Parse(TimePicker.Text);
            DateTime date = (DateTime)DatePicker.SelectedDate;
            int type = ((Haircut)HaircutPicker.SelectedItem).Id;
            int customer = ((Customer)CustomerPicker.SelectedItem).Id;


            if(!isEdit)
                controller.AddBook(price, date, type, customer, time);
            else
            {
                t.price = price;
                t.time = time;
                t.date = date;
                t.haricut_id = type;
                t.customer_id = customer;
                controller.EditBook(t);
            }
            this.Close();
        }

        private void HaircutPickerChanged(object sender, SelectionChangedEventArgs e)
        {
            Haircut h = (Haircut)HaircutPicker.SelectedItem;
            PriceTextBox.Text = h.price.ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
