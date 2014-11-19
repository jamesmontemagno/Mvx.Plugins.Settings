using System.Collections.Generic;
using Cirrious.CrossCore;
using System;

namespace Refractored.MvxPlugins.Settings.Test.Core
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class TestSettings
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

    public static Guid GuidSetting
    {
      get
      {
        return AppSettings.GetValueOrDefault("guid_setting", Guid.Empty);
      }
      set
      {
        //if value has changed then save it!
        AppSettings.AddOrUpdateValue("guid_setting", value);
      }
    }

    public static decimal DecimalSetting
    {
      get
      {
        return AppSettings.GetValueOrDefault("decimal_setting", (decimal)0);
      }
      set
      {
        //if value has changed then save it!
        AppSettings.AddOrUpdateValue("decimal_setting", value);
      }
    }

    public static int IntSetting
    {
      get
      {
        return AppSettings.GetValueOrDefault("int_setting", (int)0);
      }
      set
      {
        //if value has changed then save it!
        AppSettings.AddOrUpdateValue("int_setting", value);
      }
    }

    public static float FloatSetting
    {
      get
      {
        return AppSettings.GetValueOrDefault("float_setting", (float)0);
      }
      set
      {
        //if value has changed then save it!
        AppSettings.AddOrUpdateValue("float_setting", value);
      }
    }

    public static Int64 Int64Setting
    {
      get
      {
        return AppSettings.GetValueOrDefault("int64_setting", (Int64)0);
      }
      set
      {
        //if value has changed then save it!
        AppSettings.AddOrUpdateValue("int64_setting", value);
      }
    }

    public static Int32 Int32Setting
    {
      get
      {
        return AppSettings.GetValueOrDefault("int32_setting", (Int32)0);
      }
      set
      {
        //if value has changed then save it!
        AppSettings.AddOrUpdateValue("int32_setting", value);
      }
    }

    public static DateTime DateTimeSetting
    {
      get
      {
        return AppSettings.GetValueOrDefault("date_setting", DateTime.Now);
      }
      set
      {
        //if value has changed then save it!
        AppSettings.AddOrUpdateValue("date_setting", value);
      }
    }

    public static double DoubleSetting
    {
      get
      {
        return AppSettings.GetValueOrDefault("double_setting", (double)0);
      }
      set
      {
        //if value has changed then save it!
        AppSettings.AddOrUpdateValue("double_setting", value);
      }
    }

    public static bool BoolSetting
    {
      get
      {
        return AppSettings.GetValueOrDefault("bool_setting", false);
      }
      set
      {
        AppSettings.AddOrUpdateValue("bool_setting", value);
      }
    }

    public static string StringSetting
    {
      get
      {
        return AppSettings.GetValueOrDefault("string_setting", "hello");
      }
      set
      {
        //if value has changed then save it!
        AppSettings.AddOrUpdateValue("string_setting", value);
      }
    }

  }
}
