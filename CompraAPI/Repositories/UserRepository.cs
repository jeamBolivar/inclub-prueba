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
    public class UserRepository : IUserRepository 
    {
        private readonly DbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
        public UserRepository(IPasswordHasher passwordHasher)
        {
            _dbContext = new DbContext();
            _passwordHasher = passwordHasher;
        }

        public void Add(User user)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"INSERT INTO users (username,password) VALUES(@username,@password)";
                user.password = _passwordHasher.Hash(user.password);
                dbConnection.Open();
                dbConnection.Execute(sQuery,user);

            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"SELECT * FROM users";
                dbConnection.Open();
                return await dbConnection.QueryAsync<User>(sQuery);               
            }
        }

        public async Task<User> GetById(int id)
        {
            using (IDbConnection dbConnection = _dbContext.Connection)   
            {
                string sQuery = @"SELECT * FROM users WHERE id=@Id";
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<User>(sQuery, new {Id = id});
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
                user.password = _passwordHasher.Hash(user.password);
                dbConnection.Open();
                dbConnection.Query(sQuery, user);
            }
        }


    }

}