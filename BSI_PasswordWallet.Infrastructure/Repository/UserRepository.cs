using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using BSI_PasswordWallet.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgresContext _dbContext;

        public UserRepository(PostgresContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            return;
        }

        public async Task<User> GetUserAsync(string login)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Login == login);
            return user;
        }
    }
}
