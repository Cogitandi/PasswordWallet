using BSI_PasswordWallet.Infrastructure.RequestModel;
using BSI_PasswordWallet.Infrastructure.ResponseModels;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Services.User
{
    public interface IUserService : IService
    {
        public Task<GetUserByIdModel> GetUserByIdAsync(GetUserByIdRequest id);
    }
}
