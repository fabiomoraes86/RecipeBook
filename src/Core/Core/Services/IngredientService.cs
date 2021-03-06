using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text.Json;

namespace Core.Services
{
    public class IngredientService : IIngredientService
    {
        private string jsonFile = @"D:\projetos\recipeBook\ListRecipeBook.json";
        private readonly string _json;
        private readonly List<RecipeBookModel> _recipeBook;
        private readonly IFileSystem _fileSystem;

        public IngredientService(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            _json = _fileSystem.File.ReadAllText(jsonFile);
            _recipeBook = JsonSerializer.Deserialize<List<RecipeBookModel>>(_json);

        }

        public IngredientModel Add(int recipeId, IngredientModel ingredient)
        {
            foreach (var recipe in _recipeBook)
            {
                if (recipe.Id == recipeId)
                {
                    ingredient.Id = GenerateId.GetId(recipe.Ingredients.Count);
                    recipe.Ingredients.Add(ingredient);
                }
            }

            var resultIngredient = JsonSerializer.Serialize(_recipeBook);

            _fileSystem.File.WriteAllText(jsonFile, resultIngredient);

            return ingredient;
        }

        public void Remove(int recipeId, int ingredientId)
        {
            foreach (var recipe in _recipeBook)
            {
                if (recipe.Id == recipeId)
                {
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        if (ingredient.Id == ingredientId)
                        {
                            recipe.Ingredients.Remove(ingredient);
                            RecipeOrderId.IngredientReorderId(recipe.Ingredients.ToList());
                            break;
                        }
                    }
                }
            }

            var resultIngredient = JsonSerializer.Serialize(_recipeBook);

            _fileSystem.File.WriteAllText(jsonFile, resultIngredient);
        }
    }
}
