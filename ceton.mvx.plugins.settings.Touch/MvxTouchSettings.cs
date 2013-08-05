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
using System.Collections.Generic;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.File;
using Newtonsoft.Json;

namespace ceton.mvx.plugins.settings.Touch
{
    public class MvxTouchSettings : ISettings
    {
        private Dictionary<string, object> m_Settings = new Dictionary<string, object>();
        readonly IMvxFileStore m_FileStore;

        private const string SettingsFile = "app_settings";
        private readonly object m_Locker = new object();

        public MvxTouchSettings()
        {
            m_FileStore = Mvx.Resolve<IMvxFileStore>();
        }

        
        public T GetValueOrDefault<T>(string key, T defaultValue = default(T)) where T : IComparable
        {
            lock (m_Locker)
            {
                if (!m_Settings.ContainsKey(key))
                    return defaultValue;

                Type typeOf = typeof (T);
                if (typeOf.IsGenericType && typeOf.GetGenericTypeDefinition() == typeof (Nullable<>))
                {
                    typeOf = Nullable.GetUnderlyingType(typeOf);
                }
                object value = null;
                var typeCode = Type.GetTypeCode(typeOf);
                switch (typeCode)
                {
                    case TypeCode.Boolean:
                        value = Convert.ToBoolean(m_Settings[key]);
                        break;
                    case TypeCode.Int64:
                        value = Convert.ToInt64(m_Settings[key]);
                        break;
                    case TypeCode.String:
                        value = Convert.ToString(m_Settings[key]);
                        break;
                    case TypeCode.Int32:
                        value = Convert.ToInt32(m_Settings[key]);
                        break;
                    case TypeCode.Single:
                        value = Convert.ToSingle(m_Settings[key]);
                        break;
                }
          

                return null != value ? (T)value : defaultValue;
            }
        }

        public bool AddOrUpdateValue(string key, object value)
        {
            lock (m_Locker)
            {

                if (!m_Settings.ContainsKey(key))
                {
                    m_Settings.Add(key, value);
                    return true;
                }

                var currentValue = m_Settings[key];
                if (currentValue != value)
                {
                    m_Settings[key] = value;
                    return true;
                }
            }

            return false;
        }

        public void Save()
        {
            try
            {
                lock (m_Locker)
                {
                    m_FileStore.WriteFile(SettingsFile, JsonConvert.SerializeObject(m_Settings, Formatting.Indented));
                }
            }
            catch (Exception)
            {

            }
        }


        public void Setup(Dictionary<string, object> defaultValues)
        {
            try
            {
                string content;
                if (m_FileStore.Exists(SettingsFile) && m_FileStore.TryReadTextFile(SettingsFile, out content))
                {
                    m_Settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
                }
                else
                {
                    m_Settings = defaultValues;
                    Save();
                }
            }
            catch (Exception)
            {
                m_Settings = defaultValues;
                Save();
            }
        }
    }

}
