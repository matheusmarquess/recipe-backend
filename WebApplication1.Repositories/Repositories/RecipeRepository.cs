using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities.Entities;
using WebApplication1.Interfaces.Repositories;
using System.Data;
using System.Collections;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Repositories.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IMongoDatabase _db;

        public RecipeRepository()
        {
            _db = new MongoClient("mongodb://192.168.99.100:6000").GetDatabase("recipes_book");
        }

        public List<Recipe> ListRecipes()
        {
            using (SqlConnection conexao = new SqlConnection("Server=DESKTOP-IGIIL8O;Database=RECIPE_BOOK;Trusted_Connection=True"))
            {
                return conexao.Query<Recipe>(Queries.RecipesQueries.LIST_RECIPES).ToList();
            }
        }

        public Recipe GetRecipe(int recipeId)
        {
            using (SqlConnection conexao = new SqlConnection("Server=DESKTOP-IGIIL8O;Database=RECIPE_BOOK;Trusted_Connection=True"))
            {
                return conexao.Query<Recipe>(Queries.RecipesQueries.GET_RECIPE, new { id = recipeId }).FirstOrDefault();
            }
        }

        public int AddRecipe(Recipe recipe)
        {
            using (SqlConnection conexao = new SqlConnection("Server=DESKTOP-IGIIL8O;Database=RECIPE_BOOK;Trusted_Connection=True"))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@name", recipe.Name, DbType.String);
                parameters.Add("@description", recipe.Description, DbType.String);
                parameters.Add("@imgPath", recipe.ImgPath, DbType.String);
                return conexao.Execute(Queries.RecipesQueries.SAVE_RECIPE, parameters);
            }
        }

        public int EditRecipe(Recipe recipe, int id)
        {
            using (SqlConnection conexao = new SqlConnection("Server=DESKTOP-IGIIL8O;Database=RECIPE_BOOK;Trusted_Connection=True"))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32);
                parameters.Add("@name", recipe.Name, DbType.String);
                parameters.Add("@description", recipe.Description, DbType.String);
                parameters.Add("@imgPath", recipe.ImgPath, DbType.String);
                return conexao.Execute(Queries.RecipesQueries.EDIT_RECIPE, parameters);
            }
        }

        public int DeleteRecipe(int recipeId)
        {
            using (SqlConnection conexao = new SqlConnection("Server=DESKTOP-IGIIL8O;Database=RECIPE_BOOK;Trusted_Connection=True"))
            {
                return conexao.Execute(Queries.RecipesQueries.DELETE_RECIPE, new { id = recipeId });
            }
        }

        public int ListRecipesMongo()
        {
            _db.CreateCollection("users");
            return 1;
        }
    }
}
