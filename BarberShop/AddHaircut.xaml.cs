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
    /// Interaction logic for AddHaircut.xaml
    /// </summary>
    public partial class AddHaircut : Window
    {
        Controller controller = new Controller();
        bool isEdit;
        Haircut haircut;
        public AddHaircut()
        {
            InitializeComponent();
            isEdit = false;
        }

        public AddHaircut(Haircut haircut)
        {
            InitializeComponent();
            this.haircut = haircut;
            UpdateHaircutInfo();            
            isEdit = true;
        }

        public void UpdateHaircutInfo()
        {
            NameTextBox.Text = haircut.name;
            PriceTextBox.Text = haircut.price.ToString();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                double price = double.Parse(PriceTextBox.Text);

                if (!isEdit)
                    controller.AddHaircut(name, price);
                else
                {
                    haircut.name = name;
                    haircut.price = price;

                    controller.EditHaircut(haircut);
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
    }
}
