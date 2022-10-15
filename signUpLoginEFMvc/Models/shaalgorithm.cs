using System.Security.Cryptography;
using System.Text;

namespace signUpLoginEFMvc.Models
{
    public class shaalgorithm
    {

        public static string AlgorithmSha(string text)
        {
            SHA256CryptoServiceProvider sHA256 = new SHA256CryptoServiceProvider();
            byte[] encode = Encoding.ASCII.GetBytes(text);
            byte[] compute = sHA256.ComputeHash(encode);

            return text;
        }



    }
}