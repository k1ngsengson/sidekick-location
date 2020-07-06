using Core.Services;
using Core.ViewModels;
using Data.Repositories;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType<ILocationsService, LocationsService>();
            Mvx.IoCProvider.RegisterType<IGoogleMapService, GoogleMapService>();
            Mvx.IoCProvider.RegisterType<ILocationsRepository, LocationsRepository>();
            //Mvx.IoCProvider.RegisterType<DatabaseContext>();

            Mvx.IoCProvider.Resolve<ILocationsService>();
            Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            Mvx.IoCProvider.Resolve<ILocationsRepository>();

            //Mvx.IoCProvider.Resolve<DatabaseContext>();
            

            RegisterAppStart<LocationListViewModel>();

        }
    }
}
