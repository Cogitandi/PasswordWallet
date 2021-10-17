using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Services.UserService
{
    public interface IUserService : IService
    {
        public Task<User> GetUserAsync(GetUserByLoginRequest id);
        public Task<bool> Login(LoginRequest request);
    }
}
