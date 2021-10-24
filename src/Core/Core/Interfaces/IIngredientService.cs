using Core.Models;

namespace Core.Interfaces
{
    public interface IIngredientService
    {
        IngredientModel Add(int recipeId, IngredientModel ingredient);

        void Remove(int recipeId, int ingredientId);
    }
}
