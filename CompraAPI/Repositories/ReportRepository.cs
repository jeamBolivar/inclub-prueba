using System.Collections.Generic;
using System.Data;
using System.Linq;
using CompraAPI.Data;
using CompraAPI.Model;
using Dapper;

namespace CompraAPI.Repositories
{
    public class ReportRepository
    {
        private readonly DbContext _dbContext;
        public ReportRepository()
        {
            _dbContext = new DbContext();
        }       

        public IEnumerable<Order> GetAllOrderByUser(int userId)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = "GetOrders"; 
                var orderDictionary = new Dictionary<int, Order>();               
                dbConnection.Open();
                var orders = dbConnection.Query<Order,OrderProduct, Order>(
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
                    splitOn: "Id")
                .Distinct()
                .ToList();

                return orders;                         
            }
        }
    }
}