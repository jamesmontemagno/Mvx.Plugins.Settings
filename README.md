Mvx Settings Plugin an MvvmCross
===================

## What is it
Cross platform settings plug-in for MvvmCross that allows you to store and use shared preferences in your core project.

Uses the native settings management
* Android: SharedPreferences
* iOS: NSUserDefaults
* Windows Phone: IsolatedStorageSettings
* Windows Store: ApplicationDataContainer

## Sample App
* Included currently is a iOS Touch sample app and a core solution under the "Test" folder.

#Setup & Usage
* Add Refractored.MvxPlugins.Settings.dll to all projects
* Add Refractored.MvxPlugins.Settings.ClientName.dll to all clients 
* Or go ahead and just all all projects in and reference them

* Create a new file in your Core solution called Settings.cs (or whatever you would like)
* This is a static class that can be used in your core or clients to get/set settings
* Fill in setup code
* Add in settings
* See the sample project for details.


## Projects which use Mvx Settings Plugin
* Want yours on the list? Open an issue :)



## TODO
* Turn into Nuget
* Sample Android App
* Sample Windows Phone App
* Sample Windows Store App

## Contributors
* [jamesmontemagno](https://github.com/jamesmontemagno)
* Originally a [ceton](https://github.com/ceton) project that has been transfered to me.

Thanks!

## License
Licensed under the [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0.html)
