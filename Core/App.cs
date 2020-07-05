﻿using Core.Services;
using Core.ViewModels;
using Data.DbContexts;
using Data.Repositories;
using MvvmCross;
using MvvmCross.IoC;
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
            //Mvx.IoCProvider.RegisterType<ILocationsRepository, LocationsRepository>();
            //Mvx.IoCProvider.RegisterType<IDatabaseContext, DatabaseContext>();

            Mvx.IoCProvider.Resolve<ILocationsService>();
            //Mvx.IoCProvider.Resolve<ILocationsRepository>();

            //Mvx.IoCProvider.Resolve<IDatabaseContext>();
            //Mvx.IoCProvider.Resolve<IGenerateDatabaseContext>();

            RegisterAppStart<LocationViewModel>();

        }
    }
}
