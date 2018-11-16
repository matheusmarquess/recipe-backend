using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces.Business;
using WebApplication1.Dtos.Dtos;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
            
        private readonly IRecipesBusiness _recipeBusiness;

        public ValuesController(IRecipesBusiness _recipeBusiness)
        {
            this._recipeBusiness = _recipeBusiness;
        }

        // GET api/values
        [HttpGet]
        public List<RecipeDto> Get()
        {
            return _recipeBusiness.ListRecipes();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID menor que 0");
            }
            else
            {

                try
                {
                    return Ok(_recipeBusiness.GetRecipe(id));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post(RecipeDto recipe)
        {
            try
            {
                return Ok(_recipeBusiness.AddRecipe(recipe));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // PUT api/values/5
        [HttpPut]
        public ActionResult Put(RecipeDto recipe)
        {
            try
            {
                return Ok(_recipeBusiness.EditRecipe(recipe.Id, recipe));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_recipeBusiness.DeleteRecipe(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
