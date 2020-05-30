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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        Controller controller = new Controller();
        SupplierOrder s;
        bool isEdit;
        public AddOrder()
        {
            InitializeComponent();
            SetComboBox();
            isEdit = false;
        }

        public AddOrder(SupplierOrder s)
        {
            InitializeComponent();
            SetComboBox();
            isEdit = true;
            this.s = s;
            UpdateOrderInfo();
        }

        private void UpdateOrderInfo()
        {
            List<Supplier> l1 = (List<Supplier>)SupplierPicker.ItemsSource;
            List<Product> l2;

            DatePicker.SelectedDate = s.date;
            AmountTextBox.Text = s.amount.ToString();
            PriceTextBox.Text = s.price.ToString();
            SupplierPicker.SelectedIndex = l1.FindIndex(x => x.Id == s.Supplier.Id);
            l2 = (List<Product>)ProductPicker.ItemsSource;
            ProductPicker.SelectedIndex = l2.FindIndex(x => x.Id == s.Product.Id);
        }

        private void SetComboBox()
        {
            SupplierPicker.ItemsSource = controller.GetSuppliers();
            SupplierPicker.DisplayMemberPath = "name";
        }

        private void SupplierPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Product> l = controller.GetProducts();
            if (SupplierPicker.SelectedIndex > -1)
            {
                ProductPicker.IsEnabled = true;
                for (int i = 0; i < l.Count;)
                {
                    if (l[i].Supplier.name != ((Supplier)SupplierPicker.SelectedItem).name)
                        l.RemoveAt(i);
                    else
                        i++;
                }
                ProductPicker.ItemsSource = l;
                ProductPicker.DisplayMemberPath = "name";
            }
            else
            {
                ProductPicker.IsEnabled = false;
                ProductPicker.SelectedIndex = -1;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int supplier = (SupplierPicker.SelectedItem as Supplier).Id;
                int product = (ProductPicker.SelectedItem as Product).Id;
                DateTime date = (DateTime)DatePicker.SelectedDate;
                int amount = int.Parse(AmountTextBox.Text);
                double price = double.Parse(PriceTextBox.Text);

                if (!isEdit)
                    controller.AddSupplierOrder(supplier, product, date, amount, price);
                else
                {
                    s.supplier_id = supplier;
                    s.product_id = product;
                    s.date = date;
                    s.amount = amount;
                    s.price = price;
                    s.Supplier = controller.GetSuppliers().Find(x => x.Id == s.supplier_id);
                    s.Product = controller.GetProducts().Find(x => x.Id == s.product_id);

                    controller.EditSupplierOrder(s);
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
