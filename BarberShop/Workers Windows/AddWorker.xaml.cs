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

namespace BarberShop.Workers_Windows
{
    /// <summary>
    /// Interaction logic for AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        Controller controller = new Controller();
        Worker w;
        bool isEdit;
        public AddWorker()
        {
            InitializeComponent();
            isEdit = false;
        }

        public AddWorker(Worker w)
        {
            InitializeComponent();
            isEdit = true;
            this.w = w;
            UpdateWorkerInfo();
        }

        private void UpdateWorkerInfo()
        {
            NameTextBox.Text = w.name;
            IdTextBox.Text = w.identification;
            AddressTextBox.Text = w.address;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string id = IdTextBox.Text;
            string address = AddressTextBox.Text;

            if(!isEdit)
                controller.AddWorker(name,id, address);
            else
            {
                w.name = name;
                w.identification = id;
                w.address = address;
                controller.EditWorker(w);
            }

            this.Close();
        }
    }
}
