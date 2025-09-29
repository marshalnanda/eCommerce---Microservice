using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.Entities.DTO;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUserRepository
    {
        private readonly DapperDbContext _dbContext;
        public UsersRepository(DapperDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId=Guid.NewGuid();
            string query = @"INSERT INTO users (UserId, Email,PersonName, Gender,Password) 
                           VALUES (@UserId, @Email,@PersonName, @Gender,@Password);";
            int rowCountAffected=await _dbContext.DbConnection.ExecuteAsync(query,user);

            return rowCountAffected > 0 ? user : null ;
        }

        public async Task<ApplicationUser?> GetUserByEmailandPassword(string? email, string? password)
        {
            string Query = "SELECT * from users where Email=@email and Password=@password";
            ApplicationUser? user =await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(Query, new { Email = email, Password = password });

            return user;
        }
    }
}
