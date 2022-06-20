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
using DishPicker.View;

namespace DishPicker.UserControls
{
    /// <summary>
    /// Логика взаимодействия для RecipeUserControl.xaml
    /// </summary>
    public partial class RecipeUserControl : UserControl
    {
        public RecipeUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RecipeWindow RecipeWindow = new RecipeWindow(DataContext);
            foreach (var window in Application.Current.Windows)
            {
                if (window is RecipeListWindow)
                    (window as Window).Hide();
            }
            RecipeWindow.Show();
        }
    }
}
