using Autofac;
using BSI_PasswordWallet.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.AutoFac
{
    class CommandsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandsModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                    .AsClosedTypesOf(typeof(ICommandHandler<>))
                    .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                    .As<ICommandDispatcher>()
                    .InstancePerLifetimeScope();
        }
    }
}
