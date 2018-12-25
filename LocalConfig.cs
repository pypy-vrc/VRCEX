using System.Collections.Generic;

namespace VRCEX
{
    public static class LocalConfig
    {
        private static Dictionary<string, object> m_ConfigData = new Dictionary<string, object>();
        private static readonly string CONFIG_FILE_NAME = "config.dat";

        public static void LoadConfig()
        {
            Utils.Deserialize(CONFIG_FILE_NAME, ref m_ConfigData);
        }

        public static void SaveConfig()
        {
            Utils.Serialize(CONFIG_FILE_NAME, m_ConfigData);
        }

        public static bool Remove(string name)
        {
            return m_ConfigData.Remove(name);
        }

        public static string GetString(string name, string defaultValue = "")
        {
            if (m_ConfigData.TryGetValue(name, out object value) &&
                value != null)
            {
                return value.ToString();
            }
            return defaultValue;
        }

        public static void SetString(string name, string value)
        {
            m_ConfigData[name] = value;
        }

        public static string GetSecureString(string name, string defaultValue = "")
        {
            var value = GetString(DESEncryption.Encrypt(name, false));
            if (!string.IsNullOrEmpty(value) &&
                DESEncryption.Decrypt(value.ToString(), out string decrypted))
            {
                return decrypted;
            }
            return defaultValue;
        }

        public static void SetSecureString(string name, string value)
        {
            SetString(DESEncryption.Encrypt(name, false), DESEncryption.Encrypt(value));
        }
    }
}