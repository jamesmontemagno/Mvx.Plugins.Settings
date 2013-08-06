Mvx Settings Plugin an MvvmCross
===================

## What is it
Cross platform settings plug-in for MvvmCross that allows you to store and use shared preferences in your core project.

Uses the native settings management (except iOS)
* Android: SharedPreferences
* iOS: JSON File
* Windows Phone: IsolatedStorageSettings
* Windows Store: ApplicationDataContainer

## Sample App
* Included currently is a iOS Touch sample app and a core solution under the "Test" folder.

#Setup & Usage
* Add ceton.mvx.plugins.settings.dll to all projects
* Add ceton.mvx.plugins.settings.ClientName.dll to all clients 
* Or go ahead and just all all projects in and reference them

* Create a new file in your Core solution called Settings.cs (or whatever you would like)
* This is a static class that can be used in your core or clients to get/set settings

*Fill in Setup:
`
 /// <summary>
/// Setup required for IOS only, put all keys and defaults here.
/// All other platforms do not use this, but in theory what you are doing here is laying out your 
/// JSON file.
/// </summary>
private static void Setup()
{
    m_Settings = Mvx.GetSingleton<ISettings>();
    m_Settings.Setup(new Dictionary<string, object>
        {
            {TimeoutKey, TimeoutDefault},
        });
}
`

Add Settings:
`
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
`


## Projects which use Mvx Settings Plugin
* Want yours on the list? Open an issue :)



## TODO
* Turn into Nuget
* Sample Android App
* Sample Windows Phone App
* Sample Windows Store App

## Contributors
* [jamesmontemagno](https://github.com/jamesmontemagno)

Thanks!

## License
Licensed under the [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0.html)