using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos.Dtos;
using WebApplication1.Entities.Entities;

namespace WebApplication1.Interfaces.Business
{
    public interface IRecipesBusiness
    {
        List<RecipeDto> ListRecipes();
        RecipeDto GetRecipe(int id);
        MensagemDto AddRecipe(RecipeDto recipe);
        MensagemDto MensagemToResponse(int status, string mensagem);
        Recipe ConvertRecipeDto(RecipeDto recipe);
        MensagemDto EditRecipe(int id, RecipeDto recipe);
        MensagemDto DeleteRecipe(int id);

        void SalvarReceita();
    }
}
