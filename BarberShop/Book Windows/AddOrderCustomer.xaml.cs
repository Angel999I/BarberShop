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
    /// Interaction logic for AddOrderCustomer.xaml
    /// </summary>
    public partial class AddOrderCustomer : Window
    {
        Controller controller = new Controller();
        bool isEdit;
        Order o;
        public AddOrderCustomer()
        {
            InitializeComponent();
            UpdateComboBox();
            isEdit = false;            
        }

        public AddOrderCustomer(Order o)
        {
            InitializeComponent();
            UpdateComboBox();
            isEdit = true;
            this.o = o;
            UpdateOrderInfo();
        }

        private void UpdateOrderInfo()
        {
            List<Customer> l1 = (List<Customer>)CustomerPicker.ItemsSource;
            List<Product> l2 = (List<Product>)ProductPicker.ItemsSource;
            List<Worker> l3 = (List<Worker>)WorkerPicker.ItemsSource;

            CustomerPicker.SelectedIndex = l1.FindIndex(x => x.Id == o.Customer.Id);
            ProductPicker.SelectedIndex = l2.FindIndex(x => x.Id == o.Product.Id);
            WorkerPicker.SelectedIndex = l3.FindIndex(x => x.Id == o.Worker.Id);
            DatePicker.SelectedDate = o.date;
            PriceTextBox.Text = o.price.ToString();
        }

        private void UpdateComboBox()
        {
            CustomerPicker.ItemsSource = controller.GetCustomers();
            CustomerPicker.DisplayMemberPath = "name";

            ProductPicker.ItemsSource = controller.GetProducts();
            ProductPicker.DisplayMemberPath = "name";

            WorkerPicker.ItemsSource = controller.GetWorkers();
            WorkerPicker.DisplayMemberPath = "name";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int customer = (CustomerPicker.SelectedItem as Customer).Id;
                int product = (ProductPicker.SelectedItem as Product).Id;
                int worker = (WorkerPicker.SelectedItem as Worker).Id;
                DateTime date = (DateTime)DatePicker.SelectedDate;
                double price = double.Parse(PriceTextBox.Text);

                if (!isEdit)
                    controller.AddOrder(customer, product, date, price, worker);
                else
                {
                    o.customer_id = customer;
                    o.product_id = product;
                    o.worker_id = worker;
                    o.date = date;
                    o.price = price;
                    o.Customer = controller.GetCustomers().Find(x => x.Id == o.customer_id);
                    o.Product = controller.GetProducts().Find(x => x.Id == o.product_id);
                    o.Worker = controller.GetWorkers().Find(x => x.Id == o.worker_id);

                    controller.EditOrder(o);
                }

                this.Close();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("One of the fields is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ensure that only numbers is present in number fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Ensure that the selection boxes are not empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
