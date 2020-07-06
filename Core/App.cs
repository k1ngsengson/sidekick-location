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
            // this line registers all the services names ending with Service
            CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();

            // register services
            Mvx.IoCProvider.RegisterType<ILocationsService, LocationsService>();
            Mvx.IoCProvider.RegisterType<IGoogleMapService, GoogleMapService>();
            Mvx.IoCProvider.RegisterType<ILocationsRepository, LocationsRepository>();
            
            // resolvers
            Mvx.IoCProvider.Resolve<ILocationsService>();
            Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            Mvx.IoCProvider.Resolve<ILocationsRepository>();

            RegisterAppStart<LocationListViewModel>();

        }
    }
}
