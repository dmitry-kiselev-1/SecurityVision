using System;
using System.Xml.Linq;

namespace SecurityVision.SilverlightClient
{
    /// <summary>
    /// Класс для чтения конфигурации appSettings из ServiceReferences.ClientConfig
    /// </summary>
    public static class SettingsReader
    {
        public static string GetAppSetting(string strKey)
        {
            string result = string.Empty;

            var xDocument = XDocument.Load("ServiceReferences.ClientConfig");
            foreach (var s in xDocument.Element("configuration").Element("appSettings").Elements("add"))
            {
                if (s.Attribute("key").Value == strKey)
                    result = s.Attribute("value").Value;
            }
            return result;
        }
    }
}
