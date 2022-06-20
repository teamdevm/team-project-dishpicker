using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        #region Коллекции для продуктов
        
        // Продукты у пользователя
        private ObservableCollection<Product> _productsCurrent = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductsCurrent { get => _productsCurrent; set => Set(ref _productsCurrent, value); }

        // Покупки у пользователя
        private ObservableCollection<Product> _purchasesCurrent = new ObservableCollection<Product>();
        public ObservableCollection<Product> PurchasesCurrent { get => _purchasesCurrent; set => Set(ref _purchasesCurrent, value); }

        // Список продуктов, которые можно использовать
        private static readonly List<AddableProduct> _productsList = new List<AddableProduct>()
        {
            new AddableProduct("Апельсин", 38, 100, "../Resources/Ingredients/orange.png"),//0
            new AddableProduct("Баклажаны", 24, 100, "../Resources/Ingredients/eggplant.png"),//1
            new AddableProduct("Бананы",91,100,"../Resources/Ingredients/banana.png"),//2
            new AddableProduct("Болгарский перец", 26, 100, "../Resources/Ingredients/paprika.png"),//3
            new AddableProduct("Броколли", 34, 100, "../Resources/Ingredients/brokolly.png"),//4
            new AddableProduct("Гранат", 52, 100, "../Resources/Ingredients/granate.png"),//5
            new AddableProduct("Груша", 42, 100, "../Resources/Ingredients/pear.png"),//6
            new AddableProduct("Йогурт", 51, 100, "../Resources/Ingredients/yogurt.png"),//7
            new AddableProduct("Кабачки", 20, 100, "../Resources/Ingredients/zucchini.png"),//8
            new AddableProduct("Капуста", 27, 100, "../Resources/Ingredients/cabbage.png"),//9
            new AddableProduct("Картофель", 80, 100, "../Resources/Ingredients/potato.png"),//10
            new AddableProduct("Киви", 46, 100, "../Resources/Ingredients/qiwi.png"),//11
            new AddableProduct("Клубника", 41, 100, "../Resources/Ingredients/strawberry.png"),//12
            new AddableProduct("Красный лук", 43, 100, "../Resources/Ingredients/red onion.png"),//13
            new AddableProduct("Кукуруза", 69, 100, "../Resources/Ingredients/corn.png"),//14
            new AddableProduct("Мандарин", 38, 100, "../Resources/Ingredients/mandarine.png"),//15
            new AddableProduct("Молоко", 42, 100, "../Resources/Ingredients/milk.png"),//16
            new AddableProduct("Морковь", 34, 100, "../Resources/Ingredients/carrots.png"),//17
            new AddableProduct("Огурцы", 14, 100, "../Resources/Ingredients/cucumbers.png"),//18
            new AddableProduct("Пекинская капуста", 16, 100, "../Resources/Ingredients/lettuce.png"),//19
            new AddableProduct("Петрушка", 23, 100, "../Resources/Ingredients/parsley.png"),//20
            new AddableProduct("Подсолнечное масло", 900, 100, "../Resources/Ingredients/oil.png"),//21
            new AddableProduct("Помидор", 23, 100, "../Resources/Ingredients/tomato.png"),//22
            new AddableProduct("Редис", 16, 100, "../Resources/Ingredients/radish.png"),//23
            new AddableProduct("Салат айсберг", 14, 100, "../Resources/Ingredients/iceberg.png"),//24
            new AddableProduct("Сахар", 399, 100, "../Resources/Ingredients/sugar.png"),//25
            new AddableProduct("Свекла", 50, 100, "../Resources/Ingredients/beets.png"),//26
            new AddableProduct("Сливочное масло", 748, 100, "../Resources/Ingredients/butter.png"),//27
            new AddableProduct("Соль", 0, 100, "../Resources/Ingredients/salt.png"),//28
            new AddableProduct("Сыр", 350, 100, "../Resources/Ingredients/cheese.png"),//29
            new AddableProduct("Тыква", 20, 100, "../Resources/Ingredients/pumpkin.png"),//30
            new AddableProduct("Чеснок", 46, 100, "../Resources/Ingredients/garlic.png"),//31
            new AddableProduct("Чили", 40, 100, "../Resources/Ingredients/chili.png"),//32
            new AddableProduct("Шампиньоны", 27, 100, "../Resources/Ingredients/mushrooms.png"),//33
            new AddableProduct("Шпинат", 16, 100, "../Resources/Ingredients/spinach.png"),//34
            new AddableProduct("Яблоко", 47, 100,"../Resources/Ingredients/apple.png"),//35
            new AddableProduct("Яйца", 142, 100, "../Resources/Ingredients/egg.png"),//36
            new AddableProduct("Мука", 342, 100, "../Resources/Ingredients/flour.png")//37
        };
        private ObservableCollection<AddableProduct> _currentAddableProducts;
        public ObservableCollection<AddableProduct> CurrentAddableProducts { get => _currentAddableProducts; set => Set(ref _currentAddableProducts, value); }
        private ObservableCollection<AddableProduct> _currentAddablePurchases;
        public ObservableCollection<AddableProduct> CurrentAddablePurchases { get => _currentAddablePurchases; set => Set(ref _currentAddablePurchases, value); }

        #endregion

        #region Рецепты и ингредиенты

        public List<Recipe> Recipes = new List<Recipe>()
        {
            new Recipe(
                "Фруктовый салат", "FruitSalad", 20, new List<Ingredient>()
                {
                    new Ingredient(_productsList[35], 150),
                    new Ingredient(_productsList[6], 150),
                    new Ingredient(_productsList[2], 150),
                    new Ingredient(_productsList[11], 150),
                    new Ingredient(_productsList[15], 150),
                    new Ingredient(_productsList[5], 100),
                    new Ingredient(_productsList[7], 250)
                }, "../Resources/Dishes/fruit salad.png"),
            new Recipe(
                "Яичные блины", "EggPancakes", 20, new List<Ingredient>()
                {
                    new Ingredient(_productsList[36], 250),
                    new Ingredient(_productsList[16], 100),
                    new Ingredient(_productsList[37], 40),
                    new Ingredient(_productsList[27], 30),
                    new Ingredient(_productsList[25], 15),
                    new Ingredient(_productsList[28], 2)
                }, "../Resources/Dishes/egg pancakes.png"),
            new Recipe(
                "Омлет с кабачками", "Omlet", 40, new List<Ingredient>()
                {
                    new Ingredient(_productsList[36], 250),
                    new Ingredient(_productsList[8], 250),
                    new Ingredient(_productsList[22], 200),
                    new Ingredient(_productsList[31], 15),
                    new Ingredient(_productsList[28], 2),
                    new Ingredient(_productsList[20], 10),
                    new Ingredient(_productsList[21], 15)
                }, "../Resources/Dishes/omlet.png")
        };

        public ObservableCollection<Recipe> _recipesCurrent = new ObservableCollection<Recipe>();
        public ObservableCollection<Recipe> RecipesCurrent { get => _recipesCurrent; set => Set(ref _recipesCurrent, value); }

        #endregion


        #region Время и дата

        private string _time;
        private string _day;

        public string Time { get => _time; set => Set(ref _time, value); }
        public string Day { get => _day; set => Set(ref _day, value); }

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

        #endregion


        #region Поля текущих продуктов

        private Product _selectedProduct;
        public Product SelectedProduct { get => _selectedProduct; set => Set(ref _selectedProduct, value); }

        private int _countProduct = 100;
        public int CountProduct { get => _countProduct; set => Set(ref _countProduct, value); }

        #endregion


        #region Команды и функции

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

        public ICommand OnRecipeGenCommand => new RelayCommand(OnRecipeGen);

        private void OnRecipeGen(object obj)
        {
            RecipesCurrent.Clear();
            foreach (var recipe in Recipes)
            {
                bool goodRecipe = true;
                foreach (var ingredient in recipe.Ingredients)
                {
                    bool goodIngredient = false;
                    foreach (var product in ProductsCurrent)
                    {
                        if (product.Name == ingredient.Product.Name && product.Weight >= ingredient.Amount)
                        {
                            goodIngredient = true;
                            break;
                        }
                    }
                    if (!goodIngredient)
                    {
                        goodRecipe = false;
                        break;
                    }
                }

                if (goodRecipe)
                    RecipesCurrent.Add(recipe);
            }
        }

        public void OnCalcAddableList(string type)
        {
            if (type == "Product")
            {
                CurrentAddableProducts = new ObservableCollection<AddableProduct>(_productsList.Select(obj => obj.Clone()));
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

            if (type == "Purchase")
            {
                CurrentAddablePurchases = new ObservableCollection<AddableProduct>(_productsList.Select(obj => obj.Clone()));
                foreach (var productCurrent in PurchasesCurrent)
                {
                    foreach (var newProduct in CurrentAddablePurchases)
                    {
                        if (productCurrent.Name == newProduct.Name)
                        {
                            newProduct.Ischecked = true;
                        }
                    }
                }
            }
        }

        #endregion


        #region Конструктор
       
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


        }
        #endregion

    }
}
