using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CompraAPI.Data;
using CompraAPI.Interfaces;
using CompraAPI.Model;
using Dapper;

namespace CompraAPI.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DbContext _dbContext;
        public ReportRepository()
        {
            _dbContext = new DbContext();
        }       

        public async Task<IEnumerable<Order>> GetAllOrderByUser(int userId)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = "GetOrders"; 
                var orderDictionary = new Dictionary<int, Order>();               
                dbConnection.Open();
                var ordersResult = await dbConnection.QueryAsync<Order,OrderProduct, Order>(
                    sQuery,                    
                    (order, orderProduct) =>
                    {
                        Order orderEntry;
                        if (!orderDictionary.TryGetValue(order.id, out orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.products = new List<OrderProduct>();
                            orderDictionary.Add(orderEntry.id, orderEntry);
                        }
                        orderEntry.products.Add(orderProduct);
                        return orderEntry;
                    },
                    new { userId = userId},
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id");               
                List<Order> orders = ordersResult.Distinct().ToList();
                return orders;                                      
            }
        }
    }
}