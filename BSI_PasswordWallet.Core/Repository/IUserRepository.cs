using BSI_PasswordWallet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Core.Repository
{
    public interface IUserRepository : IRepository
    {
        public Task AddUserAsync(User user);
        public Task<User> GetUserAsync(string login);
    }
}
