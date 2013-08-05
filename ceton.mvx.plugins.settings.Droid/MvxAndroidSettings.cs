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
using Android.App;
using Android.Content;
using Android.Preferences;

namespace ceton.mvx.plugins.settings.Droid
{
    public class MvxAndroidSettings : ISettings
    {
        private static ISharedPreferences SharedPreferences { get; set; }
        private static ISharedPreferencesEditor SharedPreferencesEditor { get; set; }
        private readonly object m_Locker = new object();

        public MvxAndroidSettings()
        {
            SharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
            SharedPreferencesEditor = SharedPreferences.Edit();

        }

        public T GetValueOrDefault<T>(string key, T defaultValue = default(T)) where T : IComparable
        {
            lock (m_Locker)
            {
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
                        value = SharedPreferences.GetBoolean(key, Convert.ToBoolean(defaultValue));
                        break;
                    case TypeCode.Int64:
                        value = SharedPreferences.GetLong(key, Convert.ToInt64(defaultValue));
                        break;
                    case TypeCode.String:
                        value = SharedPreferences.GetString(key, Convert.ToString(defaultValue));
                        break;
                    case TypeCode.Int32:
                        value = SharedPreferences.GetInt(key, Convert.ToInt32(defaultValue));
                        break;
                    case TypeCode.Single:
                        value = SharedPreferences.GetFloat(key, Convert.ToSingle(defaultValue));
                        break;
                }

                return null != value ? (T) value : defaultValue;
            }
        }

        public bool AddOrUpdateValue(string key, object value)
        {
            lock (m_Locker)
            {
                Type typeOf = value.GetType();
                if (typeOf.IsGenericType && typeOf.GetGenericTypeDefinition() == typeof (Nullable<>))
                {
                    typeOf = Nullable.GetUnderlyingType(typeOf);
                }
                var typeCode = Type.GetTypeCode(typeOf);
                switch (typeCode)
                {
                    case TypeCode.Boolean:
                        SharedPreferencesEditor.PutBoolean(key, Convert.ToBoolean(value));
                        break;
                    case TypeCode.Int64:
                        SharedPreferencesEditor.PutLong(key, Convert.ToInt64(value));
                        break;
                    case TypeCode.String:
                        SharedPreferencesEditor.PutString(key, Convert.ToString(value));
                        break;
                    case TypeCode.Int32:
                        SharedPreferencesEditor.PutInt(key, Convert.ToInt32(value));
                        break;
                    case TypeCode.Single:
                        SharedPreferencesEditor.PutFloat(key, Convert.ToSingle(value));
                        break;
                }
            }

            return true;
        }

        public void Save()
        {
            lock (m_Locker)
            {
                SharedPreferencesEditor.Commit();
            }
        }

        public void Setup(System.Collections.Generic.Dictionary<string, object> defaultValues)
        {
        }
    }
}
