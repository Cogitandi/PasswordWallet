using BSI_PasswordWallet.Core.Domain;
using BSI_PasswordWallet.Core.Repository;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAccount(CreateAccountRequest request)
        {
            User user = new User(request.Login, request.Password, request.IsPasswordKeptAsHash);
            await _userRepository.AddUserAsync(user);
        }

        public async Task<User> GetUserAsync(GetUserByLoginRequest model)
        {
            var core = await _userRepository.GetUserAsync(model.Login);

            return core;
        }

        public async Task<bool> IsCredentialsValidAsync(LoginRequest request)
        {
            User user = await _userRepository.GetUserAsync(request.Login);
            bool credentialsOk = user != null && user.PasswordHash == request.Password;
            return credentialsOk;
        }
    }
}
