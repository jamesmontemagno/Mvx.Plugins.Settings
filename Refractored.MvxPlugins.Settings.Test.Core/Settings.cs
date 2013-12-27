using System.Collections.Generic;
using Cirrious.CrossCore;

namespace Refractored.MvxPlugins.Settings.Test.Core
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Simply setup your settings once when it is initialized.
        /// </summary>
        private static ISettings m_Settings;
        private static ISettings AppSettings
        {
            get
            {
                return m_Settings ?? (m_Settings = m_Settings = Mvx.GetSingleton<ISettings>());
            }
        }

#region Setting Constants

        /// <summary>
        /// Key for your setting
        /// </summary>
        public const string TimeoutKey = "timeout";
        /// <summary>
        /// default value for your setting
        /// </summary>
        public const int TimeoutDefault = 8;

#endregion

        /// <summary>
        /// Timeout setting example. Gets or sets the timeout int
        /// </summary>
        public static int Timeout
        {
            get
            {
                return AppSettings.GetValueOrDefault(TimeoutKey, TimeoutDefault);
            }
            set
            {
                //if value has changed then save it!
                if (AppSettings.AddOrUpdateValue(TimeoutKey, value))
                    AppSettings.Save();
            }
        }

    }
}
