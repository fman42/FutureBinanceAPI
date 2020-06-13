using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace FutureBinanceAPI.Tools.Cipher
{
    class RequestCrypter
    {
        public static string CreateHMAC(string secretKey, FormUrlEncodedContent args)
        {
            HMACSHA256 hash = new HMACSHA256(GetBytes(secretKey));
            byte[] bytes = hash.ComputeHash(args.ReadAsByteArrayAsync().Result);
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        private static byte[] GetBytes(string arg) => new ASCIIEncoding().GetBytes(arg);
    }
}
