using Core.Models;
using System.Collections.Generic;

namespace Core.Extensions
{
    public class RecipeOrderId
    {
        public static void RecipeReorderId(List<RecipeBookModel> recipeBook)
        {
            int id = 1;
            for (int i = 0; i < recipeBook.Count; i++)
            {
                recipeBook[i].Id = id;

                id++;
            }
        }

        public static void IngredientReorderId(List<IngredientModel> ingredient)
        {
            int id = 1;
            for (int i = 0; i < ingredient.Count; i++)
            {
                ingredient[i].Id = id;

                id++;
            }
        }
    }
}
