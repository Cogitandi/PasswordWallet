using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Infrastructure.Commands.CreateUser;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Services.UserService
{
    public interface IUserService : IService
    {
        public Task CreateAccount(CreateUserCommand request);
        public Task<User> GetUserAsync(GetUserByLoginRequest request);
        public Task<bool> IsCredentialsValidAsync(LoginRequest request);
    }
}
