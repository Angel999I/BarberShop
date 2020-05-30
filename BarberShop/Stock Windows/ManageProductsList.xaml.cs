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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BarberShop
{
    /// <summary>
    /// Interaction logic for ManageProductsList.xaml
    /// </summary>
    public partial class ManageProductsList : Window
    {
        Controller controller = new Controller();
        public ManageProductsList()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            controller = null;
            controller = new Controller();
            ProductsDataGrid.ItemsSource = controller.GetProducts();
        }

        private void NewProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProduct window = new AddProduct();
            window.ShowDialog();
            UpdateDataGrid();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            Product p = (Product)ProductsDataGrid.SelectedItem;
            controller.DeleteProduct(p);
            UpdateDataGrid();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            Product p = (Product)ProductsDataGrid.SelectedItem;
            AddProduct window = new AddProduct(p);
            window.ShowDialog();
            UpdateDataGrid();
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