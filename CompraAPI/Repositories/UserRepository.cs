using System.Collections.Generic;
using System.Data;
using System.Linq;
using CompraAPI.Data;
using CompraAPI.Model;
using Dapper;

namespace CompraAPI.Repositories
{
    public class UserRepository
    {
        private readonly DbContext _dbContext;
        public UserRepository()
        {
            _dbContext = new DbContext();
        }

        public void Add(User user)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"INSERT INTO users (username,password) VALUES(@username,@password)";
                dbConnection.Open();
                dbConnection.Execute(sQuery,user);

            }
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"SELECT * FROM users";
                dbConnection.Open();
                return dbConnection.Query<User>(sQuery);               
            }
        }

        public User GetById(int id)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"SELECT * FROM users WHERE id=@Id";
                dbConnection.Open();
                return dbConnection.Query<User>(sQuery, new {Id = id}).FirstOrDefault();               
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"DELETE FROM users WHERE id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new {Id = id});
            }
        }

        public void Update(User user)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"UPDATE users SET username=@username,password=@password WHERE id=@id";
                dbConnection.Open();
                dbConnection.Query(sQuery, user);
            }
        }


    }

}