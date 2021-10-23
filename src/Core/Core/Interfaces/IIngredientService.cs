using Core.Models;

namespace Core.Interfaces
{
    public interface IIngredientService
    {
        Ingredient Add(string idRecipe, Ingredient ingredient);
        void Remove(string idRecipe, string idIngredient);
    }
}
