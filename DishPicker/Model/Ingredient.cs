using System;
using System.Collections.Generic;
using System.Text;

namespace DishPicker.Model
{
    class Ingredient
    {
        //Переходное состояние из продукта в рецепт

        // Продукт
        public Product Product { get; set; }
        
        // Количество
        public int Amount { get; set; }

        // Конструктор
        public Ingredient(Product product, int amount)
        {
            Product = product;
            Amount = amount;
        }
    }
}
