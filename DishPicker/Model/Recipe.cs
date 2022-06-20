using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DishPicker.Model
{
    public class Recipe
    {
        // Название рецепта
        public string Name { get; set; }

        // Время на готовку в минутах
        public int Time { get; set; }

        // Ссылка на картинку
        public string Source { get; set; }
        
        // Список ингредиентов
        public List<Ingredient> Ingredients { get; set; }

        // Строка ингредиентов
        public string SIngredients { get; set; }

        // Описание рецепта
        public List<string> Description { get; set; } = new List<string>();

        // Конструктор
        public Recipe(string name, string nameDescription ,int time, List<Ingredient> ingredients, string source)
        {
            Name = name;
            Time = time;
            Ingredients = ingredients;
            for (var index = 0; index < ingredients.Count; index++)
            {
                var ingredient = ingredients[index];
                SIngredients += ingredient.Product.Name;
                if(index != ingredients.Count-1)
                    SIngredients += ", ";
            }
            SIngredients += ".";

            StreamReader f = new StreamReader($"../../../Resources/RecipeInfo/{nameDescription}.txt");
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                Description.Add(s);
            }
            f.Close();

            Source = source;
        }


    }
}
