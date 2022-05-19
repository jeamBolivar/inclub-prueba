using System.Collections.Generic;
using System.Data;
using CompraAPI.Data;
using CompraAPI.Model;
using Dapper;

namespace CompraAPI.Repositories
{
    public class OrderRepository
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

        /*public IEnumerable<Order> GetAll()
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"SELECT * FROM products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);               
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"SELECT * FROM products WHERE id=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new {Id = id}).FirstOrDefault();               
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"DELETE FROM products WHERE id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new {Id = id});
            }
        }

        public void Update(Product product)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"UPDATE products SET description=@description,price=@price WHERE id=@id";
                dbConnection.Open();
                dbConnection.Query(sQuery, product);
            }
        }*/
    }
}