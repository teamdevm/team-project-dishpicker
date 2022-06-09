using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DishPicker.Model;
using DishPicker.ViewModel.Base;

namespace DishPicker.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        // Конструктор
        public MainViewModel() 
        {

        }
    }
}
