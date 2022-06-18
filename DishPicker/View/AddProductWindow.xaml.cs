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
        ObservableCollection<Product> CurrentList;
        ObservableCollection<AddableProduct> AddableList;
        public AddProductWindow(object mvm, string OwnerWindow)
        {
            InitializeComponent();
            DataContext = mvm;

            Binding bind = new Binding();
            bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            bind.Mode = BindingMode.OneWay;

            if (OwnerWindow == "Product")
            {
                (mvm as MainViewModel)?.OnCalcAddableList("Product");
                CurrentList = (DataContext as MainViewModel)?.ProductsCurrent;
                AddableList = (DataContext as MainViewModel)?.CurrentAddableProducts;
                bind.Path = new PropertyPath("CurrentAddableProducts");
            }
            if(OwnerWindow == "Purchase")
            {

                (mvm as MainViewModel)?.OnCalcAddableList("Purchase");
                CurrentList = (DataContext as MainViewModel)?.PurchasesCurrent;
                AddableList = (DataContext as MainViewModel)?.CurrentAddablePurchases;
                bind.Path = new PropertyPath("CurrentAddablePurchases");
            }
            ItemsControl.SetBinding(ItemsControl.ItemsSourceProperty, bind);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var product in AddableList)
            {
                if (product.Ischecked)
                {
                    bool isExists = false;
                    foreach (var productCurrent in CurrentList)
                    {
                        if (productCurrent.Name == product.Name)
                        {
                            isExists = true;
                            break;
                        }
                    }
                    if(!isExists)
                        CurrentList.Add(new Product(product.Name, product.Kkal, product.Weight, product.Source));
                }

                if (!product.Ischecked)
                {
                    foreach (var productCurrent in CurrentList)
                    {
                        if (productCurrent.Name == product.Name)
                        {
                            CurrentList.Remove(productCurrent);
                            break;
                        }
                    }
                        
                }
            }
        }
    }
}
