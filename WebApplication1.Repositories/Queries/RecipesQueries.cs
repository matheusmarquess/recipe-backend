using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repositories.Queries
{
    public static class RecipesQueries
    {
        public static string LIST_RECIPES => "SELECT * FROM recipes";
        public static string GET_RECIPE => "SELECT * FROM recipes WHERE id = @id";
        public static string GET_LAST_RECIPE => "SELECT * FROM recipes WHERE id = (SELECT MAX(id) FROM recipes)";
        public static string SAVE_RECIPE => "INSERT INTO recipes VALUES (@name, @description, @imgPath)";
        public static string EDIT_RECIPE => "UPDATE recipes SET name=@name, description=@description, imgPath=@imgPath WHERE id=@id";
        public static string DELETE_RECIPE => "DELETE FROM recipes WHERE id=@id";
    }
}
