using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ContaSimples.BusinessCore.Entities;

namespace ContaSimples.WebApi.Infra
{
    public static class ClienteTokenService
    {
        public static string GenerateTokenFromCliente(Cliente cliente)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, cliente.Email),
                    new Claim("Documento", cliente.Documento),
                     new Claim("CodigoCliente", cliente.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static Cliente ClienteFromToken(string token)
        {
            Cliente cliente = null;

            try
            {
                var tokenValidate = JWTDecrypt(token);

                cliente = new Cliente();

                MontaClienteObject(cliente, tokenValidate);

                return cliente;
            }
            catch (Exception ex)
            {
            }

            return cliente;

        }

        private static ClaimsPrincipal JWTDecrypt(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var xpto = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            SecurityToken securityToken;

            var tokenValidate = tokenHandler.ValidateToken(token, xpto, out securityToken);
            return tokenValidate;
        }

        private static void MontaClienteObject(Cliente cliente, ClaimsPrincipal tokenValidate)
        {
            foreach (var item in tokenValidate.Claims)
            {
                if (item.Type == ClaimTypes.Email)
                {
                    cliente.Email = item.Value;
                }

                if (item.Type == "Documento")
                {
                    cliente.Documento = item.Value;
                }
                if (item.Type == "CodigoCliente")
                {
                    cliente.Id = int.Parse( item.Value);
                }
            }
        }
    }
}
