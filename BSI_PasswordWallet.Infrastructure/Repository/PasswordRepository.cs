using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using BSI_PasswordWallet.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Repository
{
    class PasswordRepository : IPasswordRepository
    {
        private readonly PostgresContext _dbContext;

        public PasswordRepository(PostgresContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPasswordAsync(Password password)
        {
            _dbContext.Passwords.Add(password);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Password>> GetPasswordsAsync(User user)
        {
            List<Password> userPasswords = await _dbContext.Passwords
                                                           .Where(p => p.User == user)
                                                           
                                                           .ToListAsync();
            return userPasswords;
        }

        public async Task UpdateAsync(params Password[] passwords)
        {
            foreach(Password item in passwords)
            {
                _dbContext.Passwords.Update(item);
            }
            //_dbContext.Passwords.Update(password);
            await _dbContext.SaveChangesAsync();
        }
    }
}
