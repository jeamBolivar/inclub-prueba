using System.Data;
using System.Data.SqlClient;

namespace CompraAPI.Data
{
    public class DbContext
    {
        private string connectionString;

        public DbContext()
        {
            connectionString = @"Persist Security Info=False;User ID=sa;password=localhost;Initial Catalog=ShopDB;Data Source=.;Connection Timeout=1000000;";            
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

    }
}