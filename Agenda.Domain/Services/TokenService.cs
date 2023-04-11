using Agenda.Domain.DTOs;
using Agenda.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Agenda.Domain.Services
{
    public class TokenService
    {        
        public static UsuarioToken GeraToken(Usuario usuario)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                usuario.IsAdmin ? new Claim(ClaimTypes.Role, "IsAdmin") : new Claim(ClaimTypes.Role, "IsUser"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(double.Parse(config["TokenConfiguration:ExpireHours"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: config["TokenConfiguration:Issuer"],
                audience: config["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,                
                signingCredentials: credentials);

            var usuarioSaida = new UsuarioSaidaDto
            {
                Id = usuario.Id,
                Email = usuario.Email,
                IsAdmin = usuario.IsAdmin,
                PessoaId = usuario.PessoaId,
                Pessoa = usuario.Pessoa,
            };

            return new UsuarioToken()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                Message = "Token JWT OK",
                Usuario = usuarioSaida,
            };
        }
    }
}
