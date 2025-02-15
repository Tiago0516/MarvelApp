using System.Security.Cryptography;
using System.Text;

namespace Marvel.Infrastructure.Utils
{
    public static class Utilidades
    {
        public static string GenerarMd5Hash(long timestamp, string privateKey, string publicKey)
        {
            var input = $"{timestamp}{privateKey}{publicKey}";
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
