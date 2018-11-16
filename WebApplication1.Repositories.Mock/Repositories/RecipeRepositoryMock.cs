using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities.Entities;
using WebApplication1.Interfaces.Repositories;

namespace WebApplication1.RecipeRepositories.Mock.Repositories
{
    public class RecipeRepositoryMock :IRecipeRepository
    {
        private static List<Recipe> _listaRecipe = new List<Recipe>() { };

        public List<Recipe> ListRecipes()
        {
            return _listaRecipe;
        }

        public Recipe GetRecipe(int recipeId)
        {
            return _listaRecipe.FirstOrDefault(x => x.Id == recipeId);
        }

        public int AddRecipe(Recipe recipe)
        {
            _listaRecipe.Add(recipe);
            return 1;
        }

        public int EditRecipe(Recipe recipe, int id)
        {
            var index = _listaRecipe.FindIndex(x => x.Id == id);
            _listaRecipe[index] = recipe;
            return 1;
        }

        public int DeleteRecipe(int recipeId)
        {
            _listaRecipe.RemoveAll(x => x.Id == recipeId);
            return 1;
        }

    }
}
