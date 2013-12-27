using Cirrious.MvvmCross.ViewModels;

namespace Refractored.MvxPlugins.Settings.Test.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private string _hello = string.Empty;
        /// <summary>
        /// This is a quick test to output last value and then set default.
        /// </summary>
        public string Hello
		{ 
			get
			{
                _hello = Settings.Timeout.ToString() + " ";
                Settings.Timeout = Settings.TimeoutDefault;
                _hello += Settings.Timeout.ToString();
			    return _hello;
			}
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        private string _hello2 = string.Empty;
        /// <summary>
        /// This is a quick test to output the default and then output a new one.
        /// See iOS example.
        /// </summary>
        public string Hello3
        {
            get
            {
                _hello2 = Settings.Timeout.ToString() + " ";
                Settings.Timeout = 10;
                _hello2 += Settings.Timeout.ToString();
                return _hello2;
            }
            set { _hello2 = value; RaisePropertyChanged(() => Hello3); }
        }
    }
}
