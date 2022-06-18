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
        // Продукты у пользователя
        public ObservableCollection<Product> ProductsCurrent { get => _productsCurrent; set => Set(ref _productsCurrent, value); }

        private List<AddableProduct> _productsList = new List<AddableProduct>()
        {
            new AddableProduct("Апельсин", 38, 100, "../Resources/Ingredients/orange.png"),
            new AddableProduct("Баклажаны", 24, 100, "../Resources/Ingredients/eggplant.png"),
            new AddableProduct("Бананы",91,100,"../Resources/Ingredients/banana.png"),
            new AddableProduct("Болгарский перец", 26, 100, "../Resources/Ingredients/paprika.png"),
            new AddableProduct("Броколли", 34, 100, "../Resources/Ingredients/brokolly.png"),
            new AddableProduct("Гранат", 52, 100, "../Resources/Ingredients/granate.png"),
            new AddableProduct("Груша", 42, 100, "../Resources/Ingredients/pear.png"),
            new AddableProduct("Йогурт", 51, 100, "../Resources/Ingredients/yogurt.png"),
            new AddableProduct("Кабачки", 20, 100, "../Resources/Ingredients/zucchini.png"),
            new AddableProduct("Капуста", 27, 100, "../Resources/Ingredients/cabbage.png"),
            new AddableProduct("Картофель", 80, 100, "../Resources/Ingredients/potato.png"),
            new AddableProduct("Киви", 46, 100, "../Resources/Ingredients/qiwi.png"),
            new AddableProduct("Клубника", 41, 100, "../Resources/Ingredients/strawberry.png"),
            new AddableProduct("Красный лук", 43, 100, "../Resources/Ingredients/red onion.png"),
            new AddableProduct("Кукуруза", 69, 100, "../Resources/Ingredients/corn.png"),
            new AddableProduct("Мандарин", 38, 100, "../Resources/Ingredients/mandarine.png"),
            new AddableProduct("Молоко", 42, 100, "../Resources/Ingredients/milk.png"),
            new AddableProduct("Морковь", 34, 100, "../Resources/Ingredients/carrots.png"),
            new AddableProduct("Огурцы", 14, 100, "../Resources/Ingredients/cucumbers.png"),
            new AddableProduct("Пекинская капуста", 16, 100, "../Resources/Ingredients/lettuce.png"),
            new AddableProduct("Петрушка", 23, 100, "../Resources/Ingredients/parsley.png"),
            new AddableProduct("Подсолнечное масло", 900, 100, "../Resources/Ingredients/oil.png"),
            new AddableProduct("Помидор", 23, 100, "../Resources/Ingredients/tomato.png"),
            new AddableProduct("Редис", 16, 100, "../Resources/Ingredients/radish.png"),
            new AddableProduct("Салат айсберг", 14, 100, "../Resources/Ingredients/iceberg.png"),
            new AddableProduct("Сахар", 399, 100, "../Resources/Ingredients/sugar.png"),
            new AddableProduct("Свекла", 50, 100, "../Resources/Ingredients/beets.png"),
            new AddableProduct("Сливочное масло", 748, 100, "../Resources/Ingredients/butter.png"),
            new AddableProduct("Соль", 0, 100, "../Resources/Ingredients/salt.png"),
            new AddableProduct("Сыр", 350, 100, "../Resources/Ingredients/cheese.png"),
            new AddableProduct("Тыква", 20, 100, "../Resources/Ingredients/pumpkin.png"),
            new AddableProduct("Чеснок", 46, 100, "../Resources/Ingredients/garlic.png"),
            new AddableProduct("Чили", 40, 100, "../Resources/Ingredients/chili.png"),
            new AddableProduct("Шампиньоны", 27, 100, "../Resources/Ingredients/mushrooms.png"),
            new AddableProduct("Шпинат", 16, 100, "../Resources/Ingredients/spinach.png"),
            new AddableProduct("Яблоко", 47, 100,"../Resources/Ingredients/apple.png"),
            new AddableProduct("Яйца", 142, 100, "../Resources/Ingredients/egg.png")
        };

        private ObservableCollection<AddableProduct> _currentAddableProducts;
        public ObservableCollection<AddableProduct> CurrentAddableProducts { get => _currentAddableProducts; set => Set(ref _currentAddableProducts, value); }

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

        public void OnCalcAddableProduct()
        {
            CurrentAddableProducts = new ObservableCollection<AddableProduct>(_productsList);
            foreach (var productCurrent in ProductsCurrent)
            {
                foreach (var newProduct in CurrentAddableProducts)
                {
                    if (productCurrent.Name == newProduct.Name)
                    {
                        newProduct.Ischecked = true;
                    }
                }
            }
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
