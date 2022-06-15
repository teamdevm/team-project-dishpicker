﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DishPicker.Model
{
    class Product
    {
        // Название продукта
        public string Name { get; set; }
        
        // Калорийность продукта
        public int Kkal { get; set; }

        // Масса продукта
        public int Weight { get; set; }

        // Конструктор
        public Product( string name, int kkal, int weight)
        {
            Name = name;
            Kkal = kkal;
            Weight = weight;
        }
    }
}