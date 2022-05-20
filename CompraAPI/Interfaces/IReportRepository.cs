using System.Collections.Generic;
using System.Threading.Tasks;
using CompraAPI.Model;

namespace CompraAPI.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<Order>> GetAllOrderByUser(int userId);        
    }
}