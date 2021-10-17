using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.ResponseModels
{
    public class GetUserByIdModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
