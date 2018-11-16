using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos.Dtos;
using WebApplication1.Entities.Entities;
using WebApplication1.Interfaces.Business;
using WebApplication1.Interfaces.Repositories;

namespace WebApplication1.Business.Business
{
    public class RecipeBusiness : IRecipesBusiness
    {
        readonly private IRecipeRepository _recipeRepository;

        public RecipeBusiness(IRecipeRepository _recipeRepository)
        {
            this._recipeRepository = _recipeRepository;
        }

        public void SalvarReceita()
        {
            throw new NotImplementedException();
        }

        public List<RecipeDto> ListRecipes()
        {
            var recipeMongo = _recipeRepository.ListRecipesMongo();
            var RecipesToResponse = new List<RecipeDto>();
            var ListOfRecipes = _recipeRepository.ListRecipes();
            foreach(var Recipe in ListOfRecipes)
            {
                RecipesToResponse.Add( new RecipeDto()
                {
                    Id= Recipe.Id,
                    Name = Recipe.Name,
                    Description = Recipe.Description,
                    ImgPath = Recipe.ImgPath
                });
            }
            return RecipesToResponse;
        }

        public RecipeDto GetRecipe(int id)
        {
            var RecipesToResponse = new RecipeDto();
            var SelectedRecipe = _recipeRepository.GetRecipe(id);
            RecipesToResponse = new RecipeDto()
            {
                Id = SelectedRecipe.Id,
                Name = SelectedRecipe.Name,
                Description = SelectedRecipe.Description,
                ImgPath = SelectedRecipe.ImgPath
            };
            return RecipesToResponse;
        }

        public MensagemDto AddRecipe(RecipeDto recipe)
        {
            var RecipeToAdd = ConvertRecipeDto(recipe);
            var status = _recipeRepository.AddRecipe(RecipeToAdd);
            return MensagemToResponse(1, "Recipe Add");
        }

        public MensagemDto EditRecipe(int id,RecipeDto recipe)
        {
            var RecipeToAdd = ConvertRecipeDto(recipe);
            var status = _recipeRepository.EditRecipe(RecipeToAdd, id);
            return MensagemToResponse(1, "Recipe Edit");
        }

        public MensagemDto DeleteRecipe(int id)
        {
            var status = _recipeRepository.DeleteRecipe(id);
            return MensagemToResponse(1, "Recipe Delete");
        }

        public MensagemDto MensagemToResponse(int status, string mensagem)
        {
            var MensagemToResponse = new MensagemDto() {
                Status = status,
                Mensagem = mensagem
            };
            return MensagemToResponse;
        }

        public Recipe ConvertRecipeDto(RecipeDto recipe)
        {
            return (new Recipe()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                ImgPath = recipe.ImgPath
            });
        }
    }
}
