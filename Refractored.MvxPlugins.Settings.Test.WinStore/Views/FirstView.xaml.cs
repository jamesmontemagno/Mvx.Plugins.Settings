using Cirrious.MvvmCross.WindowsCommon.Views;

namespace Refractored.MvxPlugins.Settings.Test.WinStore.Views
{
    public sealed partial class FirstView : MvxWindowsPage
    {
        public FirstView()
        {
            this.InitializeComponent();
            Test.Core.TestStuff.Test();
        }
    }
}
