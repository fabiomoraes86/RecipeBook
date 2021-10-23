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

        [HttpPost("add/{id}")]
        public Ingredient Add(string idRecipe, [FromBody] Ingredient ingredient)
        {
            return _ingredient.Add(idRecipe, ingredient);
        }

    }
}
