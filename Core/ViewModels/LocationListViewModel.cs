using Core.Services;
using Data.Entities;
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
            LoadData();
            Title = "Locations";
            IsBusy = false;
        }

        private ObservableCollection<Location> _locations;
        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                RaisePropertyChanged(() => Locations);
            }
        }

        public async void LoadData()
        {
            Locations = new ObservableCollection<Location>(await _service.GetLocationsAsync());

        }

        public ICommand RedirectToAddLocationCommand
        {
            get { return new MvxCommand(RedirectToAddLocation); }
        }

        public async void RedirectToAddLocation()
        {
            await _navigationService.Navigate<LocationItemViewModel>();
        }
    }
}
