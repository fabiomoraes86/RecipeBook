using System.Collections.Generic;

namespace Core.Models
{
    public class RecipeBookRequest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public string Instruction { get; set; }
    }

}
