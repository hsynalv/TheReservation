using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Application_.Abstractions.Token;
using API.Application_.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application_.DTOs.Token CreateAccessToken(int second, string username,string Id)
        {
            Application_.DTOs.Token token = new();

            //Security Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            // Claim'leri ekliyoruz
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username), // Kullanıcı adını Claim olarak ekliyoruz
                new Claim(JwtRegisteredClaimNames.NameId, Id), // Kullanıcı adını Claim olarak ekliyoruz
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Token ID'si (benzersiz)
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()) // Token'ın oluşturulma zamanı
            };

            //Oluşturulacak token ayarlarını veriyoruz.
            token.Expiration = DateTime.UtcNow.AddSeconds(second); // Todo burayı daha sonra minute olarak değiştir.
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                claims: claims,
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );

            //Token oluşturucu sınıfından bir örnek alalım.
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;
        }


        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();

            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}

    
