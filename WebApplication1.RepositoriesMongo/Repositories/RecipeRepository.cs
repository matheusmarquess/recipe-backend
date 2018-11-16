using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities.Entities;
using WebApplication1.Interfaces.Repositories;
using WebApplication3.Controllers.Models;

namespace WebApplication1.RepositoriesMongo.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IMongoDatabase _db;

        public RecipeRepository(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Recipe> ListRecipes()
        {
            return  _db.GetCollection<Recipe>("Recipe");
        }

        public Recipe GetRecipe(int recipeId)
        {
            return new Recipe();

        }

        public int AddRecipe(Recipe recipe)
        {
            return 1;
        }

        public int EditRecipe(Recipe recipe, int id)
        {
            return 1;
        }

        public int DeleteRecipe(int recipeId)
        {
            return 1;
        }


    }
}
