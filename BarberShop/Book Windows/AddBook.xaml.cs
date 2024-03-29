﻿using System;
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
            List<Worker> l3 = (List<Worker>)WorkerPicker.ItemsSource;
            //MessageBox.Show(l1.FindIndex(x => x == t.Customer).ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            DatePicker.SelectedDate = t.date;
            TimePicker.Text = t.time.ToString();
            CustomerPicker.SelectedIndex = l1.FindIndex(x => x.Id == t.Customer.Id);
            HaircutPicker.SelectedIndex = l2.FindIndex(x => x.Id == t.Haircut.Id);
            WorkerPicker.SelectedIndex = l3.FindIndex(x => x.Id == t.worker_id);
            PriceTextBox.Text = (((t.Haircut.price - t.price) / t.Haircut.price)*100).ToString();
        }

        private void SetComboBox()
        {
            CustomerPicker.ItemsSource = controller.GetCustomers();
            CustomerPicker.DisplayMemberPath = "name";

            HaircutPicker.ItemsSource = controller.GetHaircuts();
            HaircutPicker.DisplayMemberPath = "name";

            WorkerPicker.ItemsSource = controller.GetWorkers();
            WorkerPicker.DisplayMemberPath = "name";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double discount = (double.Parse(PriceTextBox.Text))/100;
                TimeSpan time = TimeSpan.Parse(TimePicker.Text);
                DateTime date = (DateTime)DatePicker.SelectedDate;
                Haircut type = (HaircutPicker.SelectedItem as Haircut);
                int customer = (CustomerPicker.SelectedItem as Customer).Id;
                int worker = (WorkerPicker.SelectedItem as Worker).Id;


                if (!isEdit)
                    controller.AddBook(type.price - (type.price * discount), date, type.Id, customer, time, worker);
                else
                {
                    t.price = type.price - (type.price * discount);
                    t.time = time;
                    t.date = date;
                    t.haricut_id = type.Id;
                    t.customer_id = customer;
                    t.worker_id = worker;
                    t.Customer = controller.GetCustomers().Find(x => x.Id == t.customer_id);
                    t.Haircut = controller.GetHaircuts().Find(x => x.Id == t.haricut_id);
                    t.Worker = controller.GetWorkers().Find(x => x.Id == t.worker_id);

                    controller.EditBook(t);
                }

                this.Close();
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show("One of the fields is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(FormatException ex)
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
