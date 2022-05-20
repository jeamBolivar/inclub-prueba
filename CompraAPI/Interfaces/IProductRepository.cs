using System.Collections.Generic;
using System.Threading.Tasks;
using CompraAPI.Model;

namespace CompraAPI.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);      
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        void Delete(int id);    
        void Update(Product product);
    }
}