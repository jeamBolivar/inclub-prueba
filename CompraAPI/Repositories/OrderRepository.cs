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
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _dbContext;
        public OrderRepository()
        {
            _dbContext = new DbContext();
        }

        public void Add(Order order)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"INSERT INTO orders (user_id) OUTPUT INSERTED.id VALUES(@user_id)";
                dbConnection.Open();
                var orderId = dbConnection.ExecuteScalar<int>(sQuery, param: order);               

                string sQuery2 = @"INSERT INTO order_product (order_id,product_id,quantity) VALUES(@order_id,@product_id,@quantity)";
                foreach (var item in order.products)
                {
                    dbConnection.Execute(sQuery2, new { order_id = orderId, product_id = item.product_id, quantity = item.quantity});
                }

                string sQuery3 = @"SELECT SUM (p.price*o.quantity) FROM order_product o LEFT JOIN products p ON o.product_id = p.id WHERE o.order_id = @orderId";
                var total = dbConnection.ExecuteScalar<int>(sQuery3, new {orderId = orderId});

                string sQuery4 = @"UPDATE orders SET total=@total WHERE id=@orderId";                
                dbConnection.Query(sQuery4, new {total = total, orderId = orderId});
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"SELECT * FROM orders o LEFT JOIN order_product op ON o.id = op.order_id";
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
                    splitOn: "Id");
                List<Order> orders = ordersResult.Distinct().ToList();
                return orders;                
            }
        }

        public async Task<Order> GetById(int id)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"SELECT * FROM orders WHERE id=@Id";
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Order>(sQuery, new {Id = id});
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"DELETE FROM order_product WHERE order_id=@Id";
                string sQuery2 = @"DELETE FROM orders WHERE id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new {Id = id});
                dbConnection.Execute(sQuery2, new {Id = id});
            }
        }

        public void Update(Order order)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"UPDATE orders SET user_id=@user_id WHERE id=@id";
                dbConnection.Open();
                dbConnection.Query(sQuery, order);

                string sQuery2 = @"UPDATE order_product SET product_id=@product_id,quantity=@quantity WHERE id=@id";
                dbConnection.Execute(sQuery2, order.products);

                string sQuery3 = @"SELECT SUM (p.price*o.quantity) FROM order_product o LEFT JOIN products p ON o.product_id = p.id WHERE o.order_id = @orderId";
                var total = dbConnection.ExecuteScalar<int>(sQuery3, new {orderId = order.id});

                string sQuery4 = @"UPDATE orders SET total=@total WHERE id=@orderId";                
                dbConnection.Query(sQuery4, new {total = total, orderId = order.id});               
            }
        }
    }
}