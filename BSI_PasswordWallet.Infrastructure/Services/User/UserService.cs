using BSI_PasswordWallet.Core.Repository;
using BSI_PasswordWallet.Infrastructure.RequestModel;
using BSI_PasswordWallet.Infrastructure.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdModel> GetUserByIdAsync(GetUserByIdRequest model)
        {
            var core = await _userRepository.GetUserAsync(model.Login);

            var result = new GetUserByIdModel()
            {
                Login = core.Login,
                Password = core.PasswordHash
            };
            return result;
        }
    }
}
