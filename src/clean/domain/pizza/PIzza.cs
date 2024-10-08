using clean.core;

namespace clean.domain.pizza{

    public class Pizza : EntityBase{

        public string Name {get; private set;}
        public string Description {get; private set;}
        public string Url {get; private set;}
        private HashSet<Ingredient> _ingredients = new HashSet<Ingredient>();

        protected Pizza(Guid id, string name, string description, string url) : base(id)
        {
            Name = name;
            Description = description;
            Url = url;
        }

        public static Pizza Create(string name, string description, string url, IEnumerable<Ingredient> ingredients ){
            var pizza = new Pizza(Guid.NewGuid(), name, description, url);

            foreach(var ingredient in ingredients){
                pizza.AddIngredient(ingredient);
            }

            return pizza;
        }

        public double GetPrice()
        {
            return _ingredients.Sum(i => i.Price) * 1.2;
        }

        public void AddIngredient(Ingredient ingredient){
            _ingredients.Add(ingredient);
        }

        public void RemoveIngredient(Ingredient ingredient){
            _ingredients.Remove(ingredient);
        }

        public IReadOnlyCollection<Ingredient> GetIngredients () => _ingredients;

        public void Update(string name, string description, string url){
            Name = name;
            Description = description;
            Url = url;
        }
    }
}