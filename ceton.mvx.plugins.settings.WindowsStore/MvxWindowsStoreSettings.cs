/*
 * MvxSettings:
 * Copyright (C) 2013 Ceton Corp: 
 * 
 * Contributors:
 * http://github.com/JamesMontemagno
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 */

using System;
using Windows.Storage;

namespace ceton.mvx.plugins.settings.WindowsStore
{
    public class MvxWindowsStoreSettings : ISettings
    {
        private static ApplicationDataContainer Settings
        {
            get { return ApplicationData.Current.LocalSettings; }
        }

        private readonly object m_Locker = new object();
        public T GetValueOrDefault<T>(string key, T defaultValue = default(T)) where T : IComparable
        {
            T value;
            lock (m_Locker)
            {
                // If the key exists, retrieve the value.
                if (Settings.Values.ContainsKey(key))
                {
                    value = (T) Settings.Values[key];
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
                if (Settings.Values.ContainsKey(key))
                {

                    // If the value has changed
                    if (Settings.Values[key] != value)
                    {
                        // Store key new value
                        Settings.Values[key] = value;
                        valueChanged = true;
                    }
                }
                    // Otherwise create the key.
                else
                {
                    Settings.CreateContainer(key, ApplicationDataCreateDisposition.Always);
                    Settings.Values[key] = value;
                    valueChanged = true;
                }
            }

            return valueChanged;
        }

        public void Save()
        {
            //nothing to do it is automatic
        }


        public void Setup(System.Collections.Generic.Dictionary<string, object> defaultValues)
        {
        }

    }
}
