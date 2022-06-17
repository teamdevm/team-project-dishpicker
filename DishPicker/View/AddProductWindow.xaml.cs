using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DishPicker.Model;
using DishPicker.ViewModel;

namespace DishPicker.View
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow(object mvm)
        {
            InitializeComponent();
            DataContext = mvm;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var product in (DataContext as MainViewModel).ProductsList)
            {
                if(product.Ischecked)
                    (DataContext as MainViewModel).ProductsCurrent.Add(new Product(product.Name, product.Kkal, product.Weight ,product.Source));
            }
            foreach (var product in (DataContext as MainViewModel).ProductsList)
            {
                if (product.Ischecked)
                    product.Ischecked = false;
            }
        }
    }
}
