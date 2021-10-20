using BSI_PasswordWallet.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Database
{
    public class PostgresContext : DbContext
    {
        private static ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
            .AddFile("app.log", append: true)
            .AddConsole((options) => { })
            .AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information);
        });
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseNpgsql("Server=localhost;Database=BSI_PasswordWallet;User Id=user;Password=password;Port=1101");
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
