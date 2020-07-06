using Core.Models;
using Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class LocationListViewModel : BaseViewModel
    {
        private readonly ILocationsService _service;
        private readonly IMvxNavigationService _navigationService;

        public LocationListViewModel(ILocationsService service, IMvxNavigationService navigationService)
        {
            _service = service;
            _navigationService = navigationService;

            LoadData().ConfigureAwait(false);

            MapVisible = true;
            ListVisible = false;
        }

        #region Properties
        private bool _mapVisible;
        public bool MapVisible
        {
            get { return _mapVisible; }
            set
            {
                _mapVisible = value;
                RaisePropertyChanged(() => MapVisible);
            }
        }

        private bool _listVisible;
        public bool ListVisible
        {
            get { return _listVisible; }
            set
            {
                _listVisible = value;
                RaisePropertyChanged(() => ListVisible);
            }
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
        #endregion

        #region Methods
        public async Task LoadData()
        {
            Addresses = new ObservableCollection<AddressInfo>(await _service.GetLocationsAsync());            
        }
        #endregion

        #region Commands
        public ICommand RedirectToAddLocationCommand
        {
            get { return new MvxCommand(async () => await OnRedirectToAddLocation()); }
        }

        public ICommand ShowMapCommand
        {
            get { return new MvxCommand(OnShowMapCommand); }
        }
        public ICommand ShowListCommand
        {
            get { return new MvxCommand(OnShowListCommand); }
        }
        #endregion

        #region Events
        public async Task OnRedirectToAddLocation()
        {
            await _navigationService.Navigate<LocationItemViewModel>();
        }

        public void OnShowMapCommand()
        {
            MapVisible = true;
            ListVisible = false;
        }

        public void OnShowListCommand()
        {
            MapVisible = false;
            ListVisible = true;
        }        
        #endregion
    }
}
