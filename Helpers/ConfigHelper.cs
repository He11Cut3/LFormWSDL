using System;
using System.Configuration;
using LForm.Extensions;
using System.Web.Configuration;
using LForm.ServiceReference;

namespace LForm.Helpers
{
    public class ConfigHelper
    {
       
        private const string Prefix = "config";

        public static T GetValue<T>(string key, string prefix = Prefix)
        {
            var entry = string.Format("{0}:{1}", prefix, key);

            // Make sure the key represents a possible valid entry
            if (string.IsNullOrWhiteSpace(entry))
                return default(T);

            var value = ConfigurationManager.AppSettings[entry];

            
            if (string.IsNullOrWhiteSpace(value))
                return default(T);

            
            if (typeof(T).IsEnum)
                return (T)Enum.Parse(typeof(T), value, true);

           
            if (typeof(T) == typeof(bool) && value.ToType<bool>())
                
                return (T)Convert.ChangeType(value.ToType<int>(), typeof(T));

            
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T SetValue<T>(string key, string value)
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~");

            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            return default(T);
        }
    }
}
