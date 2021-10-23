using AutoMapper;
using Core.Models;

namespace Core.Utils
{
    public class RecipeAutoMapper : Profile
    {
        public RecipeAutoMapper()
        {
            CreateMap<RecipeBookRequest, RecipeBookResponse>();
        }
    }
}
