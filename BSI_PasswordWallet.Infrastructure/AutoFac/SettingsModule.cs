using Autofac;
using BSI_PasswordWallet.Infrastructure.Commands;
using BSI_PasswordWallet.Infrastructure.Extension;
using BSI_PasswordWallet.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.AutoFac
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<EncryptionSettings>()).SingleInstance();
            //var assembly = typeof(CommandsModule).GetTypeInfo().Assembly;

            //builder.RegisterAssemblyTypes(assembly)
            //        .AsClosedTypesOf(typeof(ICommandHandler<>))
            //        .InstancePerLifetimeScope();

            //builder.RegisterType<CommandDispatcher>()
            //        .As<ICommandDispatcher>()
            //        .InstancePerLifetimeScope();
        }
    }
}
