using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;
using DishPicker.Model;
using DishPicker.ViewModel;

namespace DishPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            // восстановление массива из файла
            if (File.Exists("ProductCurrent.xml"))
            {
                using (FileStream fs = new FileStream("ProductCurrent.xml", FileMode.OpenOrCreate))
                {
                    var formatter = new XmlSerializer(typeof(ObservableCollection<Product>));
                    (DataContext as MainViewModel).ProductsCurrent = formatter.Deserialize(fs) as ObservableCollection<Product>;
                }
            }
            if (File.Exists("AddingProduct.xml"))
            {
                using (FileStream fs = new FileStream("AddingProduct.xml", FileMode.OpenOrCreate))
                {
                    var formatter = new XmlSerializer(typeof(ObservableCollection<AddableProduct>));
                    (DataContext as MainViewModel).ProductsList = formatter.Deserialize(fs) as ObservableCollection<AddableProduct>;
                }
            }
        }

        private void OpenProductWindow_Click(object sender, RoutedEventArgs e)
        {
            ProductListWindow productWindow = new ProductListWindow(DataContext);
            productWindow.Owner = this;
            this.Hide();
            productWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // сохранение массива текущих продуктов в файл
            using (FileStream fs = new FileStream("ProductCurrent.xml", FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Product>));
                formatter.Serialize(fs, (DataContext as MainViewModel).ProductsCurrent);
            }

            // сохранение массива добавляемых продуктов в файл
            using (FileStream fs = new FileStream("AddingProduct.xml", FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<AddableProduct>));
                formatter.Serialize(fs, (DataContext as MainViewModel).ProductsList);
            }
        }
    }
}
