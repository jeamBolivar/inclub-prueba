using System.Collections.Generic;
using System.Threading.Tasks;
using CompraAPI.Model;

namespace CompraAPI.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);      
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        void Delete(int id);    
        void Update(Order order);
    }
}