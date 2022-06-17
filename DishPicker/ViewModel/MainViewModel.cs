using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using DishPicker.Command;
using DishPicker.Model;
using DishPicker.View;
using DishPicker.ViewModel.Base;

namespace DishPicker.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Product> _productsCurrent = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductsCurrent { get => _productsCurrent; set => Set(ref _productsCurrent, value); }

        private ObservableCollection<AddableProduct> _productsList = new ObservableCollection<AddableProduct>()
        {
            new AddableProduct("Апельсин", 47, 100, "../Resources/orange.png"),
            new AddableProduct("Молоко", 42, 500, "../Resources/milk.png")
        };

        public ObservableCollection<AddableProduct> ProductsList { get => _productsList; set => Set(ref _productsList, value); }

        private string _time;
        private string _day;

        public string Time { get => _time; set => Set(ref _time, value); }
        public string Day { get => _day; set => Set(ref _day, value); }

        private Product _selectedProduct;
        public Product SelectedProduct { get => _selectedProduct; set => Set(ref _selectedProduct, value); }

        private int _countProduct = 100;
        public int CountProduct { get => _countProduct; set => Set(ref _countProduct, value); }

        public ICommand OnAddCommand => new RelayCommand(OnAdd, _ => ProductsCurrent.Count < 25);

        private void OnAdd(object obj)
        {
            ProductsCurrent.Add(new Product(_selectedProduct.Name, _selectedProduct.Kkal, _countProduct, _selectedProduct.Source));
            foreach (Window window in Application.Current.Windows)
            {
                if (window is AddProductWindow)
                {
                    window.Owner.Show();
                    window.Close();
                }
            }
        }

        public ICommand OnDeleteCommand => new RelayCommand(OnDelete);

        private void OnDelete(object obj)
        {
            ProductsCurrent.Remove(obj as Product);
        }

        // Конструктор
        public MainViewModel() 
        {
            // Время
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { Time = DateTime.Now.ToString("HH:mm"); };
            timer.Start();

            _time = DateTime.Now.ToString("HH:mm");
            _day = ConvertDay();

            //for (var i = 0; i < 40; i++)
            //    ProductsCurrent.Add(new Product("",111,111,"../Resources/orange.png"));
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
