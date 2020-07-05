using Core;
using MvvmCross.Platform.Platform;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;

namespace Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup() : base()
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected IMvxTrace CreateDebugTrace()
        {
            return new Logger();
        }
    }
}