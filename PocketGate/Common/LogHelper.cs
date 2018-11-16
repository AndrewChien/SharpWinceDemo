using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection; 

namespace PocketGate.Common
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class LogHelper
    {
        private readonly string _dir = 
            System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + @"\Log\";

        private readonly string _logDirectory = 
            string.Format(
                System.IO.Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName) + @"\Log\" + "{0}.txt",
                        DateTime.Now.ToString("yyyyMMdd"));

        public LogHelper()
        {
            this.GetLogFilePath();
        }

        /// <summary>
        /// 获取日志文件路径
        /// </summary>
        /// <returns></returns>
        private void GetLogFilePath()
        {
            try
            {
                if (!Directory.Exists(_dir.Remove(_dir.Length - 1, 1)))
                {
                    Directory.CreateDirectory(_dir.Remove(_dir.Length - 1, 1));
                }
            }
            catch (Exception)
            {
                //_logDirectory = string.Empty;
            }
        }

        /// <summary>
        /// 追加一条信息
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(_logDirectory)) return;

            using (var sw = new StreamWriter(_logDirectory, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }

        /// <summary>
        /// 追加一行信息
        /// </summary>
        /// <param name="text"></param>
        public void WriteLine(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(_logDirectory)) return;

            text += "\r\n\r\n\r\n";
            using (var sw = new StreamWriter(_logDirectory, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
