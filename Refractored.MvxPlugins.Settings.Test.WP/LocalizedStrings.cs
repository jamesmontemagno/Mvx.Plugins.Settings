using Refractored.MvxPlugins.Settings.Test.WP.Resources;

namespace Refractored.MvxPlugins.Settings.Test.WP
{
  /// <summary>
  /// Provides access to string resources.
  /// </summary>
  public class LocalizedStrings
  {
    private static AppResources _localizedResources = new AppResources();

    public AppResources LocalizedResources { get { return _localizedResources; } }
  }
}