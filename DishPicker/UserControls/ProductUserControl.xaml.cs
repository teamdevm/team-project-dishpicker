using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DishPicker.Model;
using DishPicker.ViewModel;
using DishPicker.Command;

namespace DishPicker.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    { 
        public ProductUserControl()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty MyDataContextProperty =
            DependencyProperty.Register(
                nameof(MyDataContext),
                typeof(object),
                typeof(ProductUserControl));
        public object MyDataContext { get => (object) GetValue(MyDataContextProperty); set => SetValue(MyDataContextProperty, value); }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)((ProductListWindow)MyDataContext).Mvm).ProductsCurrent.Remove((Product)this.DataContext);
        }
    }
}
