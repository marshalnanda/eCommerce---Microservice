using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration)
        { 
            _configuration=configuration;
            string? connectionString = _configuration.GetConnectionString("SQLConnectionString");
            _connection = new SqlConnection(connectionString);
        }
        public IDbConnection DbConnection => _connection;
    }
}
