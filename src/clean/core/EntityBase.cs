namespace clean.core{

    public abstract class EntityBase
    {

        public Guid Id { get; }
    
        //Constructor sin parámetros por EF
        protected EntityBase()
        {
        }

        protected EntityBase(Guid id)
        {
            Id = id;
        }
    
        public override bool Equals(object? obj) => obj is EntityBase other && other.Id == Id;
    
        public override int GetHashCode() => Id.GetHashCode();
    }
}