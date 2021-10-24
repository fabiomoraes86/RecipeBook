using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Core.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private string jsonFile = @"D:\projetos\recipeBook\ListRecipeBook.json";
        private readonly string _recipeListData;
        private readonly List<RecipeBookModel> _recipeBook;

        public RecipeBookService()
        {
            _recipeListData = File.ReadAllText(jsonFile);
            _recipeBook = JsonSerializer.Deserialize<List<RecipeBookModel>>(_recipeListData);
        }

        public ICollection<RecipeBookModel> Add(RecipeBookModel recipe)
        {
            recipe.Id = GenerateId.GetId(_recipeBook.Count);

            _recipeBook.Add(recipe);

            var resultRecipe = JsonSerializer.Serialize(_recipeBook);
            File.WriteAllText(jsonFile, resultRecipe);

            return _recipeBook;
        }

        public ICollection<RecipeBookModel> GetAll()
        {
            return _recipeBook;
        }

        public RecipeBookModel GetById(int Id)
        {
            var recipeBook = _recipeBook.FirstOrDefault(recipe => recipe.Id == Id);

            if (recipeBook == null)
                return new RecipeBookModel();

            return recipeBook;
        }

        public void Remove(int Id)
        {
            _recipeBook.RemoveAll(recipe => recipe.Id == Id);

            RecipeOrderId.RecipeReorderId(_recipeBook);

            var result = JsonSerializer.Serialize(_recipeBook);

            File.WriteAllText(jsonFile, result);
        }

        public RecipeBookModel Update(int id, RecipeBookModel newRecipeBook)
        {
            foreach (var recipeBook in _recipeBook)
            {
                if (recipeBook.Id == id)
                {
                    recipeBook.Title = newRecipeBook.Title;
                    recipeBook.Ingredients = newRecipeBook.Ingredients;
                    recipeBook.Instruction = newRecipeBook.Instruction;
                }
            }

            var result = JsonSerializer.Serialize(_recipeBook);
            File.WriteAllText(jsonFile, result);

            return _recipeBook.FirstOrDefault(recipe => recipe.Id == id);
        }
    }
}
