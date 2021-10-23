using System.Collections.Generic;

namespace Core.Models
{
    public class RecipeBookResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public string Instruction { get; set; }
    }
}
