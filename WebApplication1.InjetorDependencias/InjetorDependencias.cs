using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business.Business;
using WebApplication1.Interfaces.Business;
using WebApplication1.Interfaces.Repositories;
using WebApplication1.Repositories.Repositories;
using SimpleInjector;
using WebApplication1.RecipeRepositories.Mock.Repositories;
using WebApplication1.Repositories.Moq.Repositories;

namespace WebApplication1.InjetorDependencias
{
    public static class InjetorDependencias
    {
        private static Container _container;

        public static void Iniciar()
        {
            if (_container != null)
                _container.Dispose();

            _container = new Container();
            
            _container.Register<IRecipeRepository, RecipeRepository>();

            _container.Register<IRecipesBusiness, RecipeBusiness>();

            _container.Verify();
        }

        public static void IniciarMoq()
        {
            if (_container != null)
                _container.Dispose();

            _container = new Container();

            _container.Register<IRecipeRepository, RecipeRepositoryMoq>();

            _container.Register<IRecipesBusiness, RecipeBusiness>();

            _container.Verify();
        }

        public static void IniciarMock()
        {
            if (_container != null)
                _container.Dispose();

            _container = new Container();

            _container.Register<IRecipeRepository, RecipeRepositoryMock>();

            _container.Register<IRecipesBusiness, RecipeBusiness>();

            _container.Verify();
        }

        public static T ObterInstancia<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public static Container Container
        {
            get
            {
                return _container;
            }
        }

    }
}
