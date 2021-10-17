using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Core.Domain
{
    public class Password
    {
        public Guid Id { get; set; }
        public string PasswordValue { get; set; }
        public User User { get; set; }
        public string WebAddress { get; set; }
        public string Description { get; set; }
        public string Login { get; set; }
    }
}
