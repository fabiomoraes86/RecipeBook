namespace Core.Extensions
{
    public static class GenerateId
    {
        public static int GetId(int numberRecipeBook)
        {
            var recipeBookId = ++numberRecipeBook;
            return recipeBookId;
        }
    }
}
