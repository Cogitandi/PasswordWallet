using Autofac;
using BSI_PasswordWallet.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.AutoFac
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<IService>())
                    .AsImplementedInterfaces()
                    .SingleInstance();

        }
    }
}
