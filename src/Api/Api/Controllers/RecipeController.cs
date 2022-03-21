using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace RecipeBook.Api.Controllers
{
    [ApiController]
    [Route("v1/recipeBook")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeBookService _recipeBook;

        public RecipeController(IRecipeBookService recipeBook)
        {
            _recipeBook = recipeBook;
        }

        [HttpPost]
        public ICollection<RecipeBookModel> Add([FromBody] RecipeBookModel recipe)
        {
            return _recipeBook.Add(recipe);
        }

        [HttpGet]
        public ICollection<RecipeBookModel> GetAll()
        {
            return _recipeBook.GetAll();
        }

        [HttpGet("{id}")]
        public RecipeBookModel GetById(int id)
        {
            return _recipeBook.GetById(id);
        }

        [HttpPost("remove/{id}")]
        public IActionResult Remove(int id)
        {
            _recipeBook.Remove(id);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public RecipeBookModel Update(int id, [FromBody] RecipeBookModel recipe)
        {
            return _recipeBook.Update(id, recipe);
        }
    }
}
