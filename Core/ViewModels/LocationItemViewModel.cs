using Core.Services;
using Data.Entities;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class LocationItemViewModel : BaseViewModel
    {
        private readonly ILocationsService _service;
        private readonly IMvxNavigationService _navigationService;

        public LocationItemViewModel(ILocationsService service, IMvxNavigationService navigationService)
        {
            _service = service;
            _navigationService = navigationService;

            Title = "Add Location";
            IsBusy = false;
        }

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                RaisePropertyChanged(() => Address);
            }
        }


        public ICommand AddCommand
        {
            get { return new MvxCommand(DoAdd); }
        }

        private async void DoAdd()
        {
            var location = new Location()
            {
                Address = Address
            };

            bool save = await _service.AddLocationAsync(location);

            if (save)
                await _navigationService.Navigate<LocationListViewModel>();
        }
    }
}
