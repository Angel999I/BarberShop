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
    /// Interaction logic for AddClockHours.xaml
    /// </summary>
    public partial class AddClockHours : Window
    {
        Controller controller = new Controller();
        bool isEdit;
        WorkerHour w;
        public AddClockHours()
        {
            InitializeComponent();
            isEdit = false;
            UpdateComboBox();
        }

        public AddClockHours(WorkerHour w)
        {
            InitializeComponent();
            this.w = w;
            isEdit = true;
            UpdateComboBox();
            UpdateClockHourInfo();
        }

        private void UpdateClockHourInfo()
        {
            List<Worker> l = (List<Worker>)WorkerPicker.ItemsSource;

            WorkerPicker.SelectedIndex = l.FindIndex(x => x.Id == w.Worker.Id);
            HoursTextBox.Text = w.hours.ToString();
            SalaryTextBox.Text = w.salary.ToString();
            DatePicker.SelectedDate = w.date;
        }

        private void UpdateComboBox()
        {
            WorkerPicker.ItemsSource = controller.GetWorkers();
            WorkerPicker.DisplayMemberPath = "name";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int hours = int.Parse(HoursTextBox.Text);
            double salary = double.Parse(SalaryTextBox.Text);
            DateTime date = (DateTime)DatePicker.SelectedDate;
            int worker = ((Worker)WorkerPicker.SelectedItem).Id;

            if(!isEdit)
            controller.AddWorkerHour(worker, hours, salary, date);

            else
            {
                w.hours = hours;
                w.salary = salary;
                w.date = date;
                w.worker_id = worker;
                controller.EditWorkerHour(w);
            }

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
