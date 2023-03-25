using Agenda.Shared.Errors;
using DevOne.Security.Cryptography.BCrypt;
using System.Net;

namespace Agenda.Shared.Services
{
    public class Crypt
    {
        private static readonly int _workfactor = 10;
        public static string GerarHash(string valor)
        {
            string salt = BCryptHelper.GenerateSalt(_workfactor);
            return BCryptHelper.HashPassword(valor, salt);
        }

        public static bool Comparar(string hash, string valor)
        {
            var result = BCryptHelper.CheckPassword(valor, hash);

            if (!result)
            {
                throw new CustomException(HttpStatusCode.Unauthorized, "Email ou senha inválido!");
            }

            return result;
        }
    }
}
