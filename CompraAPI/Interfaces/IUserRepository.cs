using System.Collections.Generic;
using System.Threading.Tasks;
using CompraAPI.Model;

namespace CompraAPI.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);      
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        void Delete(int id);    
        void Update(User user);
    }
}