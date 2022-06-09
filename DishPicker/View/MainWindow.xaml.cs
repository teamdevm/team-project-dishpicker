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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { txtbxTime.Text = DateTime.Now.ToString("HH:mm"); };
            timer.Start();

            txtbxTime.Text = DateTime.Now.ToString("HH:mm");
            txtbxDate.Text = ConvertDay();
        }

        private static string ConvertDay()
        {
            return DateTime.Now.ToString("dddd") switch
            {
                "понедельник" => "ПН",
                "вторник" => "ВТ",
                "среда" => "СР",
                "четверг" => "ЧТ",
                "пятница" => "ПТ",
                "суббота" => "СБ",
                "воскресенье" => "ВС",
                _ => "ХЗ",
            };
        }
    }
}
