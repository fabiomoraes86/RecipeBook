using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace RecipeBook.Api.Controllers
{
    [ApiController]
    [Route("v1/recipe")]
    public class RecipeController : ControllerBase

    {
        private readonly IRecipeBookService _recipeBook;

        public RecipeController(IRecipeBookService recipeBook)
        {
            _recipeBook = recipeBook;
        }

        [HttpPost]
        public ICollection<RecipeBookResponse> Add([FromBody] RecipeBookRequest recipe)
        {
            return _recipeBook.Add(recipe);
        }

        [HttpGet]
        public ICollection<RecipeBookResponse> GetAll()
        {
            return _recipeBook.GetAll();
        }

        [HttpGet("{id}")]
        public RecipeBookResponse GetById(string id)
        {
            return _recipeBook.GetById(id);
        }

        [HttpPost("remove/{id}")]
        public IActionResult Remove(string id)
        {
            _recipeBook.Remove(id);
            return Ok();
        }



    }
}
