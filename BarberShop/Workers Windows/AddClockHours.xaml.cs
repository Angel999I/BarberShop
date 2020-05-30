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
            try
            {
                int hours = int.Parse(HoursTextBox.Text);
                double salary = double.Parse(SalaryTextBox.Text);
                DateTime date = (DateTime)DatePicker.SelectedDate;
                int worker = (WorkerPicker.SelectedItem as Worker).Id;

                if (!isEdit)
                    controller.AddWorkerHour(worker, hours, salary, date, salary * hours);

                else
                {
                    w.hours = hours;
                    w.salary = salary;
                    w.date = date;
                    w.worker_id = worker;
                    w.total = w.salary * w.hours;
                    w.Worker = controller.GetWorkers().Find(x => x.Id == w.worker_id);

                    controller.EditWorkerHour(w);
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

        }
    }
}
