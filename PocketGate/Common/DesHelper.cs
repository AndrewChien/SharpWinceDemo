using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PocketGate.Common
{
    public class DesHelper
    {
        #region 3des加密

        /// <summary>
        /// 3des ecb模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="originalStr">要加密的字符串</param>
        /// <returns></returns>
        public static string Encrypt3Des(string key, string originalStr)
        {
　　        try
　　        {
　　　　        if (string.IsNullOrEmpty(key)) return string.Empty;

                if (string.IsNullOrEmpty(originalStr))
                    return originalStr;

                using (var symAlgorithm = new TripleDESCryptoServiceProvider() { Key = GetBytes(key), Mode = CipherMode.ECB })
                {
                    using (var cryptoTransform = symAlgorithm.CreateEncryptor())
                    {
                        var originalBytes = GetBytes(originalStr);
                        var encryptBytes = cryptoTransform.TransformFinalBlock(originalBytes, 0, originalBytes.Length);

                        return Convert.ToBase64String(encryptBytes);
                    }
                }
　　        }
　　        catch (Exception e)
　　        {
　　　　        return string.Empty;
　　        }
        }

        #endregion

        #region 3des解密

        /// <summary>
        /// 3des 解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="ciphertextStr">密文</param>
        /// <returns></returns>
        public static string Decrypt3Des(string key, string ciphertextStr)
        {
　　        try
　　        {
　　　　        var des = new TripleDESCryptoServiceProvider
　　　　        {
                    Key = GetBytes(key),
                    Mode = CipherMode.ECB,
　　　　　　        Padding = PaddingMode.PKCS7
　　　　        };

                using (var symAlgorithm = new TripleDESCryptoServiceProvider() { Key = GetBytes(key), Mode = CipherMode.ECB })
                {
                    using (var cryptoTransform = symAlgorithm.CreateDecryptor())
                    {
                        byte[] buffer = Convert.FromBase64String(ciphertextStr);

                        return GetString(cryptoTransform.TransformFinalBlock(buffer, 0, buffer.Length));
                    }
                }
　　        }
　　        catch (Exception e)
　　        {
　　　　        return string.Empty;
　　        }
        }

        #endregion

        private static byte[] GetBytes(string data)
        {
            if (string.IsNullOrEmpty(data))
                return null;

            return Encoding.UTF8.GetBytes(data);
        }

        private static string GetString(byte[] bytes)
        {
            if (bytes == null || bytes.Length <= 0)
                return string.Empty;

            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
