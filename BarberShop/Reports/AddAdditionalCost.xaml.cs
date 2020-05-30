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
    /// Interaction logic for AddAdditionalCost.xaml
    /// </summary>
    public partial class AddAdditionalCost : Window
    {
        Controller controller = new Controller();
        AdditionalCost a;
        bool isEdit;
        public AddAdditionalCost()
        {
            InitializeComponent();
            isEdit = false;
        }

        public AddAdditionalCost(AdditionalCost a)
        {
            InitializeComponent();
            this.a = a;
            isEdit = true;
            UpdateAdditionalCostInfo();
        }

        private void UpdateAdditionalCostInfo()
        {
            CostTextBox.Text = a.cost.ToString();
            DescriptionTextBox.Text = a.description;
            DatePicker.SelectedDate = a.date;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double cost = double.Parse(CostTextBox.Text);
                string description = DescriptionTextBox.Text;
                DateTime date = (DateTime)DatePicker.SelectedDate;

                if (!isEdit)
                    controller.AddAdditionalCost(cost, description, date);
                else
                {
                    a.cost = cost;
                    a.description = description;
                    a.date = date;

                    controller.EditAdditionalCost(a);
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
