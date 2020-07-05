using Core.Models;
using Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class LocationListViewModel : MvxViewModel<AddressInfo>
    {
        private readonly ILocationsService _service;
        private readonly IMvxNavigationService _navigationService;

        public LocationListViewModel(ILocationsService service, IMvxNavigationService navigationService)
        {
            _service = service;
            _navigationService = navigationService;

            LoadData();
        }


        private ObservableCollection<AddressInfo> _addresses;
        public ObservableCollection<AddressInfo> Addresses
        {
            get { return _addresses; }
            set
            {
                _addresses = value;
                RaisePropertyChanged(() => Addresses);
            }
        }

        public async void LoadData()
        {
            Addresses = new ObservableCollection<AddressInfo>(await _service.GetLocationsAsync());
        }

        public ICommand RedirectToAddLocationCommand
        {
            get { return new MvxCommand(RedirectToAddLocation); }
        }

        public async void RedirectToAddLocation()
        {
            await _navigationService.Navigate<LocationItemViewModel>();
        }

        public override void Prepare(AddressInfo addressInfo)
        {
            Addresses.Add(addressInfo);
        }
    }
}
