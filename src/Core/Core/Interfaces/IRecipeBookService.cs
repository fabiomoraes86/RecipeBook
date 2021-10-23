using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRecipeBookService
    {
        ICollection<RecipeBookResponse> Add(RecipeBookRequest recipe);

        ICollection<RecipeBookResponse> GetAll();

        RecipeBookResponse GetById(string Id);

        void Update(RecipeBookRequest recipe);

        void Remove(string Id);
    }
}
