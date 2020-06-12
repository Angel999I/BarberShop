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
    /// Interaction logic for ManageHaircuts.xaml
    /// </summary>
    public partial class ManageHaircuts : Window
    {
        Controller controller = new Controller();
        public ManageHaircuts()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            HaircutDataGrid.ItemsSource = controller.GetHaircuts();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewHaircutButton_Click(object sender, RoutedEventArgs e)
        {
            AddHaircut w = new AddHaircut();
            w.ShowDialog();
            UpdateDataGrid();
        }

        private void DeleteHaircut_Click(object sender, RoutedEventArgs e)
        {
            Haircut haircut = (Haircut)HaircutDataGrid.SelectedItem;
            controller.DeleteHaircut(haircut);
            UpdateDataGrid();
        }

        private void EditHaircut_Click(object sender, RoutedEventArgs e)
        {
            Haircut haircut = (Haircut)HaircutDataGrid.SelectedItem;
            AddHaircut w = new AddHaircut(haircut);
            w.ShowDialog();
            UpdateDataGrid();
        }
    }
}
