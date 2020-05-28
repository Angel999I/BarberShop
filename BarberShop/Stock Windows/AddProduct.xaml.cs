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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        Controller controller = new Controller();
        bool isEdit;
        Product p;
        public AddProduct()
        {
            InitializeComponent();
            UpdateComboBox();
            isEdit = false;
        }

        public AddProduct(Product p)
        {
            InitializeComponent();
            UpdateComboBox();
            this.p = p;
            isEdit = true;
            UpdateProductInfo();
        }

        private void UpdateProductInfo()
        {
            List<Supplier> s = (List<Supplier>)SupplierPicker.ItemsSource;

            NameTextBox.Text = p.name;
            PriceTextBox.Text = p.price.ToString();
            DescriptionTextBox.Text = p.description;
            SupplierPicker.SelectedIndex = s.FindIndex(x => x.Id == p.Supplier.Id);
        }

        private void UpdateComboBox()
        {
            SupplierPicker.ItemsSource = controller.GetSuppliers();
            SupplierPicker.DisplayMemberPath = "name";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            double price = double.Parse(PriceTextBox.Text);
            string description = DescriptionTextBox.Text;
            int supplier = ((Supplier)SupplierPicker.SelectedItem).Id;

            if(!isEdit)
            controller.AddProduct(name,price,description,supplier);
            else
            {
                p.name = name;
                p.price = price;
                p.description = description;
                p.supplier_id = supplier;

                controller.EditProduct(p);
            }

            this.Close();
        }
    }
}
