using Core.Services;
using Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            {
                Mvx.IoCProvider.RegisterType<ILocationsService, LocationsService>();

                RegisterAppStart<AddressViewModel>();
            }
        }
    }
}
