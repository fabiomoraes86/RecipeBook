using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecipeBook.Api.Controllers
{
    [ApiController]
    [Route("v1/ingredient")]
    public class IngredientController
    {
        private readonly IIngredientService _ingredient;

        public IngredientController(IIngredientService ingredient)
        {
            _ingredient = ingredient;
        }

        [HttpPost("add/{recipeId}")]
        public IngredientModel Add(int recipeId, [FromBody] IngredientModel ingredient)
        {
            return _ingredient.Add(recipeId, ingredient);
        }

        [HttpPost("remove/{recipeId}/{ingredientId}")]
        public void Remove(int recipeId, int ingredientId)
        {
            _ingredient.Remove(recipeId, ingredientId);
        }
    }
}
