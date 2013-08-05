using System;
using System.IO.IsolatedStorage;

namespace ceton.mvx.plugins.settings.WindowsPhone
{
    public class MvxWindowsPhoneSettings : ISettings
    {
        static IsolatedStorageSettings Settings { get { return IsolatedStorageSettings.ApplicationSettings; } }
        private readonly object m_Locker = new object();
        public T GetValueOrDefault<T>(string key, T defaultValue = default(T)) where T : IComparable
        {
            T value;
            lock (m_Locker)
            {
                // If the key exists, retrieve the value.
                if (Settings.Contains(key))
                {
                    value = (T)Settings[key];
                }
                // Otherwise, use the default value.
                else
                {
                    value = defaultValue;
                }
            }

            return value;
        }

        public bool AddOrUpdateValue(string key, object value)
        {
            bool valueChanged = false;

            lock (m_Locker)
            {
                // If the key exists
                if (Settings.Contains(key))
                {

                    // If the value has changed
                    if (Settings[key] != value)
                    {
                        // Store key new value
                        Settings[key] = value;
                        valueChanged = true;
                    }
                }
                // Otherwise create the key.
                else
                {
                    Settings.Add(key, value);
                    valueChanged = true;
                }
            }

            return valueChanged;
        }

        public void Save()
        {
            lock (m_Locker)
            {
                Settings.Save();
            }
        }

        public void Setup(System.Collections.Generic.Dictionary<string, object> defaultValues)
        {
        }
    }
}
