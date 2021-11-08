using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.MVC
{
    class ErrorException : Exception
    {
        public ErrorException(string error) : base(error)
        { }
    }
}
