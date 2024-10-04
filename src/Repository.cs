/* 
    En nuestro sistema tenemos clientes que pueden:
        -Leer
        -Añadir
        -Modificar
        -Eliminar
    
    Los usuarios solo se pueden leer
*/

namespace Repository{

    public interface IGet<T>{
        void Get();
    }

    public interface IAdd<T>{
        void Add();
    }

    public interface IUpdate<T> : IGet{
        void Update();
    }

    public interface IRemove<T> : IGet{
        void Remove();
    }

    public interface IRepository : IAdd, IUpdate, IRemove{

    }

    public class CustomerRepository : IRepository{

        public void Get(){

        }

        public void Add(){
            
        }

        public void Update(){
            
        }

        public void Remove(){
            
        }
    }

    public class UserRepository : IGet{
        public void Get(){

        }
    }

    public class ServiceCostumer{

        public void Get(IGet<Customer> repository){
            repository.Get();
        }

        public void Update(IUpdate<Customer> repository){
            repository.Get();
            repository.Update();
        }

        public void Remove(IRemove<Customer> repository){
            repository.Get();
            repository.Remove();
        }

        public void Add(IAdd<Customer> repository){
            repository.Add();
        }
    }

    public class ServiceUser{

        public void Get(IGet<User> repository){
            repository.Get();
        }
    }

    public class Customer{
        public Customer(){

        }
    }

    public class User{
        public User(){
            
        }
    }
}