using BSI_PasswordWallet.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Database
{
    public class PostgresContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=BSI_PasswordWallet;User Id=user;Password=password;Port=1101");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
