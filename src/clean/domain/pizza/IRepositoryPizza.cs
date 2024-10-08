namespace clean.domain.pizza{

    public interface IAddPizza{
            void Add(Pizza pizza);
    }

    public interface IRepositoryPizza : IAddPizza{
        void Remove(Pizza pizza);

        void Update(Pizza pizza);

        Pizza Get(Guid id);
    }
}