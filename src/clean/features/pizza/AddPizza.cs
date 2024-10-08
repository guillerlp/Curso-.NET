using clean.domain.pizza;
using core.infraestructure;

namespace clean.features.pizza{

    public class Controller:Controller.IController
    {    
        private readonly IHandler _handler;
        public interface IController{
            Response handle(Request request);
        }
        private Controller(IHandler handler){
            _handler = handler;
        }
        public readonly record struct Request(string Name, string Description, string Url, IEnumerable<Ingredient> Ingredients);
        
        public readonly record struct Response(Guid Id, string Name, string Description, string Url, double Price, IEnumerable<Ingredient> Ingredients);

        private interface IHandler{     
            Response handle(Request request);
        }

        private class Handler : IHandler{

            private readonly IAddPizza _repositoryPizza;

            public Handler(IAddPizza repositoryPizza){
                _repositoryPizza = repositoryPizza;
            }

            public Response handle (Request request){
                var pizza = Pizza.Create(request.Name, request.Description, request.Url, request.Ingredients);

                _repositoryPizza.Add(pizza);

                return new Response(pizza.Id, pizza.Name, pizza.Description, pizza.Url, pizza.GetPrice(), pizza.GetIngredients());
            }
        }

        public Response handle(Request request)
        {
           return _handler.handle(request);
        }

        public static IController Create(){
            var repository = new PizzaRepository();
            var handler = new Handler(repository);
            return new Controller(handler);
        }
    }
}