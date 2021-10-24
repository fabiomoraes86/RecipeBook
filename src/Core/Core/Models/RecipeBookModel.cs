using System.Collections.Generic;

namespace Core.Models
{
    public class RecipeBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
        public string Instruction { get; set; }
    }
}
