using System;
using System.Security.Cryptography;
using System.Text;

namespace BestSignSDK
{
    public class RSAEncryption
    {
        public static RSAKey CreateKey(string privateKey, string publicKey, RSAKeySizeType size = RSAKeySizeType.L2048, RSAKeyType type = RSAKeyType.Base64)
        {
            using (var rsa = new RSACryptoServiceProvider((int)size))
            {
                return new RSAKey()
                {
                    PrivateKey = privateKey,
                    PublicKey = publicKey
                };
            }
        }
 
        public static string SignData(string source, string privateKey, Encoding encoding = null, RSAOutType outType = RSAOutType.Base64)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            var result = SignData(encoding.GetBytes(source), privateKey, RSAPrivateKeyFormat.PKCS8);

            if (outType == RSAOutType.Base64)
            {
                return Convert.ToBase64String(result);
            }
             
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("x2"));
            }

            return sb.ToString();
            }

      

        public static byte[] SignData(byte[] source, string privateKey, RSAPrivateKeyFormat format = RSAPrivateKeyFormat.PKCS8, RSAKeyType type = RSAKeyType.Base64)
        {
            var rsa = new RSACryptoServiceProvider();
            if (format == RSAPrivateKeyFormat.PKCS8)
            {
                rsa = RSAExtensions.DecodePemPrivateKey(privateKey);
            }
            else
            {
                if (type == RSAKeyType.Base64)
                    rsa.FromBase64StringByPrivateKey(privateKey);
            }
            SHA1 sh = new SHA1CryptoServiceProvider();
            return  rsa.SignData(source, sh);
        }

        public static bool VerifyData(string source, string signData, string publicKey, Encoding encoding = null, RSAOutType outType = RSAOutType.Base64, RSAKeyType type = RSAKeyType.Base64)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] sourceBytes = encoding.GetBytes(source);

            byte[] signBytes;
            if (outType == RSAOutType.Base64)
                signBytes = Convert.FromBase64String(signData);
            else
                signBytes = Convert.FromBase64String(signData);

            return VerifyData(sourceBytes, signBytes, publicKey, type);
        }

        public static bool VerifyData(byte[] source, byte[] signData, string publicKey, RSAKeyType type = RSAKeyType.Base64)
        {
            var rsa = new RSACryptoServiceProvider();
            if (type == RSAKeyType.Base64)
                rsa.FromBase64StringByPublicKey(publicKey);

            return rsa.VerifyData(source, new SHA1CryptoServiceProvider(), signData);
        }
    }
}
