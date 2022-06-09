using System;
using System.Collections.Generic;
using System.Text;

namespace DishPicker.Model
{
    class Recipe
    {
        // Название рецепта
        public string Name { get; set; }

        // Список ингредиентов
        public List<Ingredient> Ingredients { get; set; }

        // Описание рецепта
        public string Description { get; set; }

        // Конструктор
        public Recipe(string name, List<Ingredient> ingredients, string description)
        {
            Name = name;
            Ingredients = ingredients;
            Description = description;
        }
    }
}
