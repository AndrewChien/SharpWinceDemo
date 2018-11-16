using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Reflection;

namespace PocketGate
{
    /// 系统配置类
    /// </summary>
    [Serializable]
    public class Configuration
    {
        //全局公用日志类
        public static PocketGate.Common.LogHelper logger = new PocketGate.Common.LogHelper();
        //景点名称
        public string ScenicSpots = "";
        //闸机名称
        public string GateName = "";
        //软件版本
        public string Version = "1.0";
        //检票服务地址
        public string WebUrl = "";
        //3DesKey
        public string DesKey = "52C69E3A57331081823331C4";
        //DeviceId
        public string DeviceCode = "";
        //UserName
        public string UserName = "";
        //AuthInfoUrl
        public string AuthInfoUrl = "";
        //TokenUrl
        public string TokenUrl = "";
        //ShotCutPath
        public string ShotCutPath = "";
        //错误页回退默认时间
        public string ReturnDelay = "";

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static Configuration ReadConfig()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            Configuration Config = null;
            var ConfigFile = path + @"\Config.xml";
            XmlSerializer xmldes = new XmlSerializer(typeof(Configuration));
            try
            {
                var file = new XmlTextReader(ConfigFile);
                Config = xmldes.Deserialize(file) as Configuration;
                file.Close();
            }
            catch 
            {
            }
            return Config;
        }
        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <returns></returns>
        public static bool SaveConfig()
        {
            XmlSerializer xmldes = new XmlSerializer(typeof(Configuration));
            var ConfigFile = "./Config.xml";
            try
            {
                var file = XmlWriter.Create(ConfigFile);
                xmldes.Serialize(file, ConfigFile);
                file.Close();
            }
            catch 
            {
            }

            return true;
        }
        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <returns></returns>
        public static bool SaveConfig(Configuration config)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                var ConfigFile = path + @"\Config.xml";
                FileStream fs = new FileStream(ConfigFile, FileMode.Create);//覆盖
                XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
                serializer.Serialize(writer, config);
                writer.Close();
            }
            catch(Exception ex)
            {
                logger.WriteLine(ex.Message);
            }
            return true;
        }

        /// <summary>
        /// 保存配置文件2
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static bool SaveConfig2(Configuration config)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                string fileName = path + @"\Config.xml";
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode header = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.AppendChild(header);
                //创建一级节点
                XmlElement rootNode = xmlDoc.CreateElement("Configuration");
                //XmlElement xn = xmlDoc.CreateElement("user");//创建二级节点
                //xn.SetAttribute("id", config.Id + "");//<user id='1'>
                rootNode.AppendChild(GetXmlNode(xmlDoc, "ScenicSpots", config.ScenicSpots));//<name>张三</name>
                rootNode.AppendChild(GetXmlNode(xmlDoc, "GateName", config.GateName));
                rootNode.AppendChild(GetXmlNode(xmlDoc, "Version", config.Version));
                rootNode.AppendChild(GetXmlNode(xmlDoc, "WebUrl", config.WebUrl));
                rootNode.AppendChild(GetXmlNode(xmlDoc, "AuthInfoUrl", config.AuthInfoUrl));
                rootNode.AppendChild(GetXmlNode(xmlDoc, "TokenUrl", config.TokenUrl));
                rootNode.AppendChild(GetXmlNode(xmlDoc, "ShotCutPath", config.ShotCutPath));
                rootNode.AppendChild(GetXmlNode(xmlDoc, "DesKey", config.DesKey));
                rootNode.AppendChild(GetXmlNode(xmlDoc, "ReturnDelay", config.ReturnDelay));
                rootNode.AppendChild(GetXmlNode(xmlDoc, "DeviceCode", config.DeviceCode));
                rootNode.AppendChild(GetXmlNode(xmlDoc, "UserName", config.UserName));
                xmlDoc.AppendChild(rootNode);
                xmlDoc.Save(fileName);
            }
            catch (Exception ex)
            {
                logger.WriteLine(ex.Message);
            }
            return true;
        }
        private static XmlElement GetXmlNode(XmlDocument xmlDoc, string name, string value)
        {
            XmlElement xn = xmlDoc.CreateElement(name);
            xn.InnerText = value;
            return xn;
        }

    }
}
