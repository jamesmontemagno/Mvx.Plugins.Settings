using System.Collections.Generic;
using Cirrious.CrossCore;

namespace ceton.mvx.plugins.settings.test.Core
{
    public static class Settings
    {
        
        private static ISettings m_Settings;
        private static bool m_Setup;
        private static ISettings AppSettings
        {
            get
            {
               if (m_Settings == null && !m_Setup)
               {
                   Setup();
                   m_Setup = true;
               }

                return m_Settings;
            }
        }

        //Setup required for IOS only, put all keys and defaults here.
        private static void Setup()
        {
            m_Settings = Mvx.GetSingleton<ISettings>();
            m_Settings.Setup(new Dictionary<string, object>
                {
                    {TimeoutKey, TimeoutDefault},
                });
        }

        public const string TimeoutKey = "timeout";
        public const int TimeoutDefault = 8;

        public static int Timeout
        {
            get
            {
                return AppSettings.GetValueOrDefault(TimeoutKey, TimeoutDefault);
            }
            set
            {
                if (AppSettings.AddOrUpdateValue(TimeoutKey, value))
                    AppSettings.Save();
            }
        }

    }
}
