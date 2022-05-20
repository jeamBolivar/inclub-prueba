using System;
using System.Security.Cryptography;
using CompraAPI.Interfaces;
using CompraAPI.Options;
using Microsoft.Extensions.Options;

namespace CompraAPI.Services
{
    public class PasswordService : IPasswordHasher
    {
        private readonly PasswordOptions _options;
        public PasswordService(IOptions<PasswordOptions> options)
        {
            _options = options.Value;
        }
        public string Hash(string password)
        {
            using(var algorithm = new Rfc2898DeriveBytes(
                password,
                _options.SaltSize,
                _options.Iteration
            ))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);
                return $"{_options.Iteration}.{salt}.{key}";
            }
        }
    }
}