﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI_PasswordWallet.Infrastructure.Extension
{
    public static class SettingsExtension
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty);
            var configurationValue = new T();
            configuration.GetSection(section).Bind(configurationValue);
            return configurationValue;
        }
    }
}
