using System;
using System.Security.Cryptography;
using Subscriptions.Application.Common.Interfaces;

namespace Subscriptions.Application.Common.Services
{
    public class AppSecretGenerator : IAppSecretGenerator
    {
        public string GenerateKey()
        {
            using var generator = RandomNumberGenerator.Create();
            var bytes = new byte[50];
            generator.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}