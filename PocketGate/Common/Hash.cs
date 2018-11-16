using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PocketGate.Common
{
    public class Hash
    {
        #region MD5加密
        /// <summary>
        /// MD5加密 字符串
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string MD5(string Str)
        {
            return MD5(Str, "utf-8");
        }
        /// <summary>
        /// MD5加密 字符串
        /// </summary>
        /// <param name="Str"></param>
        /// <param name="encodeName">编码格式</param>
        /// <returns></returns>
        public static string MD5(string Str, string encodeName)
        {
            if (Str==null||Str==string.Empty) return string.Empty;
            return MD5(Encoding.GetEncoding(encodeName).GetBytes(Str));
        }

        /// <summary>
        /// MD5加密 二进制流
        /// </summary>
        /// <param name="b">二进制流</param>
        /// <returns></returns>
        public static string MD5(byte[] b)
        {
            if (b == null)
            {
                return string.Empty;
            }
            byte[] md5 = new MD5CryptoServiceProvider().ComputeHash(b);
            string result = System.BitConverter.ToString(md5);
            result = result.Replace("-", "");
            return result;
        }
        #endregion
    }
}
