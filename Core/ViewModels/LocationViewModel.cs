using Core.Services;
using Data.Entities;
using System.Collections.ObjectModel;

namespace Core.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        private readonly ILocationsService _service;

        public LocationViewModel(ILocationsService service)
        {
            _service = service;
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
    }
}
