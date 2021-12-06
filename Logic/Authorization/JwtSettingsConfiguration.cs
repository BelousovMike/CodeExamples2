﻿using Microsoft.Extensions.Options;
using System;

namespace Core.Authorization
{
    public class JwtSettingsConfiguration : IConfigureOptions<JwtSettings>
    {
        public void Configure(JwtSettings options)
        {
            string secret = Environment.GetEnvironmentVariable("JWT_SECRET");

            if (!string.IsNullOrEmpty(secret))
            {
                options.Secret = secret;
            }
        }
    }
}
