using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities.Entities;

namespace WebApplication1.Interfaces.Repositories
{
    public interface IRecipeRepository
    {
        List<Recipe> ListRecipes();
        Recipe GetRecipe(int id);
        int AddRecipe(Recipe recipe);
        int EditRecipe(Recipe recipe, int id);
        int DeleteRecipe(int id);
        int ListRecipesMongo();
    }
}
