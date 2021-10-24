using BSI_PasswordWallet.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Core.Repository
{
    public interface IPasswordRepository : IRepository
    {
        public Task<List<Password>> GetPasswordsAsync(User user);
        public Task AddPasswordAsync(Password password);
        public Task UpdateAsync(params Password[] password);
    }
}
