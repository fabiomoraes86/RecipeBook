using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private string jsonFile = @"D:\projetos\recipeBook\utils\ListRecipeBook.json";
        private readonly string _json;
        private readonly List<RecipeBookResponse> _recipeBook;
        private readonly IMapper _mapper;

        public RecipeBookService(IMapper mapper)
        {
            _json = File.ReadAllText(jsonFile);
            _recipeBook = JsonSerializer.Deserialize<List<RecipeBookResponse>>(_json);

            _mapper = mapper;
        }

        public ICollection<RecipeBookResponse> Add(RecipeBookRequest recipe)
        {
            var newRecipe = _mapper.Map<RecipeBookResponse>(recipe);
            
            newRecipe.Id = GenerateId(_recipeBook.Count);

            _recipeBook.Add(newRecipe);

            var resultRecipe = JsonSerializer.Serialize(_recipeBook);
            File.WriteAllText(jsonFile, resultRecipe);

            return _recipeBook;
        }

        public ICollection<RecipeBookResponse> GetAll()
        {
            return _recipeBook;
        }

        public RecipeBookResponse GetById(string Id)
        {
            var recipeBook = _recipeBook.FirstOrDefault(recipe => recipe.Id == Id);

            return recipeBook;
        }

        public void Remove(string Id)
        {
            _recipeBook.RemoveAll(recipe => recipe.Id == Id);
            var result = JsonSerializer.Serialize(_recipeBook);

            File.WriteAllText(jsonFile, result);

        }

        public void Update(RecipeBookRequest recipe)
        {
            throw new System.NotImplementedException();
        }

        public static string GenerateId(int numberRecipeBook)
        {
            var recipeBookId = numberRecipeBook + 1;
            return recipeBookId.ToString();
        }

    }
}
