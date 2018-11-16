using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities.Entities;
using WebApplication1.Interfaces.Repositories;

namespace WebApplication1.Repositories.Moq.Repositories
{
    public class RecipeRepositoryMoq: IRecipeRepository
    {

        private static List<Recipe> _listaRecipe = new List<Recipe>() { };

        private readonly Mock<IRecipeRepository> mock = null;

        public RecipeRepositoryMoq()
        {
            mock = new Mock<IRecipeRepository>();

            mock.Setup(m => m.ListRecipes()).Returns(() => 
            {
                return _listaRecipe;
            });

            mock.Setup(m => m.GetRecipe(It.IsAny<int>())).Returns((int recipeId) =>
            {
                return _listaRecipe.FirstOrDefault(x => x.Id == recipeId);
            });

            mock.Setup(m => m.AddRecipe(It.IsAny<Recipe>())).Returns((Recipe recipe) =>
            {
                _listaRecipe.Add(recipe);
                return 1;
            });

            mock.Setup(m => m.EditRecipe(It.IsAny<Recipe>(), It.IsAny<int>())).Returns((Recipe recipe, int id) =>
            {
                var index = _listaRecipe.FindIndex(x => x.Id == id);
                _listaRecipe[index] = recipe;
                return 1;
            });

            mock.Setup(m => m.DeleteRecipe(It.IsAny<int>())).Returns((int recipeId) =>
            {
                _listaRecipe.RemoveAll(x => x.Id == recipeId);
                return 1;
            });

        }

        public List<Recipe> ListRecipes()
        {
            return mock.Object.ListRecipes();
        }

        public Recipe GetRecipe(int recipeId)
        {
            return mock.Object.GetRecipe(recipeId);
        }

        public int AddRecipe(Recipe recipe)
        {
            return mock.Object.AddRecipe(recipe);
        }

        public int EditRecipe(Recipe recipe, int id)
        {
            return mock.Object.EditRecipe(recipe, id);
        }

        public int DeleteRecipe(int recipeId)
        {
            return mock.Object.DeleteRecipe(recipeId);
        }



    }
}
