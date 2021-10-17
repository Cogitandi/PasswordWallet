using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Commands
{
    interface ICommandHandler { }
    interface ICommandHandler<T> : ICommandHandler where T:ICommand
    {
        Task HandleAsync(T command);
    }
}
