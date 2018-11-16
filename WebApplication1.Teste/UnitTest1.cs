using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WebApplication1.Dtos.Dtos;
using WebApplication1.InjetorDependencias;
using WebApplication1.Interfaces.Business;

namespace WebApplication1.Teste
{
    [TestClass]
    public class UnitTest1
    {
        private IRecipesBusiness _recipeBusiness;

        [TestInitialize]
        public void IniciarTestes()
        {
            InjetorDependencias.InjetorDependencias.IniciarMoq();

            _recipeBusiness = InjetorDependencias.InjetorDependencias.ObterInstancia<IRecipesBusiness>();
        }

        [TestMethod]
        public void TesteInserirPedido_Sucesso()
        {
            var id = 1;
            var name = "Teste";
            var description = "Testando";
            var imgPath = "TestePath";

            var recipes = _recipeBusiness.ListRecipes().FirstOrDefault(x => x.Id == id); ;

            _recipeBusiness.AddRecipe(new RecipeDto()
            {
                Id =  id,
                Name = name,
                Description = description,
                ImgPath = imgPath
            });

            var recipeConsulta = _recipeBusiness.ListRecipes().FirstOrDefault(x => x.Id == id);

            Assert.IsNotNull(recipeConsulta);
            Assert.AreEqual(id, recipeConsulta.Id);
            Assert.AreEqual(name, recipeConsulta.Name);
            Assert.AreEqual(description, recipeConsulta.Description);
            Assert.AreEqual(imgPath, recipeConsulta.ImgPath);
        }

        [TestMethod]
        public void TesteEditarPedido_Sucesso()
        {
            var id = 1;
            var name = "Teste";
            var description = "Testando";
            var imgPath = "TestePath";

            var recipes = _recipeBusiness.ListRecipes().FirstOrDefault(x => x.Id == id); ;

            _recipeBusiness.AddRecipe(new RecipeDto()
            {
                Id = id,
                Name = name,
                Description = description,
                ImgPath = imgPath
            });
            
            _recipeBusiness.DeleteRecipe(id);

            var recipeConsulta = _recipeBusiness.ListRecipes().FirstOrDefault(x => x.Id == id);

            Assert.IsNull(recipeConsulta);
        }

        [TestMethod]
        public void TesteDeletarPedido_Sucesso()
        {
            var id = 1;
            var name = "Teste";
            var description = "Testando";
            var imgPath = "TestePath";

            var recipes = _recipeBusiness.ListRecipes().FirstOrDefault(x => x.Id == id); ;

            _recipeBusiness.AddRecipe(new RecipeDto()
            {
                Id = id,
                Name = name,
                Description = description,
                ImgPath = imgPath
            });
            
            id = 1;
            name = "TesteEdit";
            description = "TestandoEdit";
            imgPath = "TestePathEdit";

            var recipeEdit = new RecipeDto()
            {
                Id = id,
                Name = name,
                Description = description,
                ImgPath = imgPath
            };


            _recipeBusiness.EditRecipe(id, recipeEdit);

            var recipeConsulta = _recipeBusiness.ListRecipes().FirstOrDefault(x => x.Id == id);

            Assert.IsNotNull(recipeConsulta);
            Assert.AreEqual(id, recipeConsulta.Id);
            Assert.AreEqual(name, recipeConsulta.Name);
            Assert.AreEqual(description, recipeConsulta.Description);
            Assert.AreEqual(imgPath, recipeConsulta.ImgPath);
        }
    }
}
