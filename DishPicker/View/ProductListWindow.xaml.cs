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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DishPicker.UserControls;
using DishPicker.View;
using DishPicker.ViewModel;

namespace DishPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public object Mvm { get; set; }

        public ProductListWindow(object mvm)
        {
            InitializeComponent();
            Mvm = mvm;
            DataContext = mvm;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Show();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow productWindow = new AddProductWindow(DataContext);
            productWindow.Owner = this;
            //this.Hide();
            productWindow.Show();
        }
    }
}
