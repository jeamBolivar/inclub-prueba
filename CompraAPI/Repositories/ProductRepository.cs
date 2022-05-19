using System.Collections.Generic;
using System.Data;
using System.Linq;
using CompraAPI.Data;
using CompraAPI.Model;
using Dapper;

namespace CompraAPI.Repositories
{
    public class ProductRepository
    {
        private readonly DbContext _dbContext;
        public ProductRepository()
        {
            _dbContext = new DbContext();
        }

        public void Add(Product product)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"INSERT INTO products (description,price) VALUES(@description,@price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery,product);

            }
        }

        public IEnumerable<Product> GetAll()
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
        }

    }
}