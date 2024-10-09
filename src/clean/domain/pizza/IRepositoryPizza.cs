namespace clean.domain.pizza{

    public interface IAddPizza{
        void Add(Pizza pizza);
    }

    public interface IUpdatePizza{
        Pizza Get(Guid id);
        void Update(Pizza pizza);
    }

    public interface IRepositoryPizza : IAddPizza, IUpdatePizza{
        void Remove(Pizza pizza);
    }
}