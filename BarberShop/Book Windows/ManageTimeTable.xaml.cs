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
    /// Interaction logic for ManageTimeTable.xaml
    /// </summary>
    public partial class ManageTimeTable : Window
    {
        Controller controller = new Controller();
        public ManageTimeTable()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            controller = null;
            controller = new Controller();
            TimeTableDataGrid.ItemsSource = null;
            TimeTableDataGrid.ItemsSource = controller.GetTimeTable();
        }

        private void NewBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBook window = new AddBook();
            window.ShowDialog();
            UpdateDataGrid();
            DatePicker.SelectedDate = null;
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            List<TimeTable> l = controller.GetTimeTable();
            DateTime date = (DateTime)DatePicker.SelectedDate;
            for(int i =0; i < l.Count;)
            {
                if (DateTime.Compare(date, l[i].date) > 0)
                {
                    l.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            TimeTableDataGrid.ItemsSource = l;
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.DeleteTimeTable((TimeTable)TimeTableDataGrid.SelectedItem);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateDataGrid();
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            TimeTable t = (TimeTable)TimeTableDataGrid.SelectedItem;
            AddBook window = new AddBook(t);
            window.ShowDialog();
            UpdateDataGrid();
            DatePicker.SelectedDate = null;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
