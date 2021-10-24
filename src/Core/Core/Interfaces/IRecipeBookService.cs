using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRecipeBookService
    {
        ICollection<RecipeBookModel> Add(RecipeBookModel recipe);

        ICollection<RecipeBookModel> GetAll();

        RecipeBookModel GetById(int id);

        RecipeBookModel Update(int id, RecipeBookModel newRecipeBook);

        void Remove(int id);
    }
}