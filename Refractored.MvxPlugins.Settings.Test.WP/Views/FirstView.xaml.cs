using Cirrious.MvvmCross.WindowsPhone.Views;

namespace Refractored.MvxPlugins.Settings.Test.WP.Views
{
    public partial class FirstView : MvxPhonePage
    {
        public FirstView()
        {
            InitializeComponent();
            Test.Core.TestStuff.Test();
        }
    }
}