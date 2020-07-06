using Acr.UserDialogs;
using Core.Models;
using Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class LocationItemViewModel : BaseViewModel
    {
        private readonly ILocationsService _service;
        private readonly IMvxNavigationService _navigationService;
        private readonly IGoogleMapService _googleMapService;


        public LocationItemViewModel(ILocationsService service, IMvxNavigationService navigationService, IGoogleMapService googleMapService)
        {
            _service = service;
            _navigationService = navigationService;
            _googleMapService = googleMapService;

            Title = "Add Location";
            IsBusy = false;
        }

        #region Properties
        private Place _selectedAddress;
        public Place SelectedAddress
        {
            get => _selectedAddress;
            set
            {
                if (_selectedAddress != value)
                {
                    _selectedAddress = value;
                    RaisePropertyChanged(() => SelectedAddress);
                }                
            }
        }

        private string _addressSearch;
        public string AddressSearch
        {
            get => _addressSearch;
            set
            {
                if (_addressSearch != value)
                {
                    _addressSearch = value;

                    if (!string.IsNullOrWhiteSpace(_addressSearch))
                    {
                        GetPlacesPredictionsAsync();
                    }

                    RaisePropertyChanged(() => Addresses);
                }
            }
        }

        private ObservableCollection<Place> _addresses;
        public ObservableCollection<Place> Addresses
        {
            get { return _addresses; }
            set
            {
                if (_addresses != value)
                {
                    _addresses = value;
                    RaisePropertyChanged(() => Addresses);
                }                
            }
        }
        #endregion

        #region Commands
        public ICommand ItemSelectedCommand
        {
            get { return new MvxCommand(OnItemSelected); }
        }
        #endregion

        #region Events
        private async void OnItemSelected()
        {
            var addressInfo = _googleMapService.GetPlaceDetails(SelectedAddress.PlaceId).Result;

            if (addressInfo != null)
            {
                bool save = await _service.AddLocationAsync(addressInfo);

                if (save)
                    await _navigationService.Navigate<LocationListViewModel>();
                else
                    UserDialogs.Instance.Alert("Failed to save to Database");                    
            }
        }
        #endregion

        #region Methods
        private async Task GetPlacesPredictionsAsync()
        {
            var predictionList = await _googleMapService.GetPlacesPredictionsAsync(AddressSearch);

            if (predictionList.Status == "OK")
            {
                if (predictionList.Predictions.Count > 0)
                {
                    Addresses = new ObservableCollection<Place>(); //because Address.Clear() doesn't work

                    foreach (Prediction prediction in predictionList.Predictions)
                    {
                        Addresses.Add(new Place()
                        {
                            PlaceId = prediction.PlaceId,
                            Address = prediction.Description
                        });
                    }
                }
            }
            else
            {
                throw new Exception(predictionList.Status);
            }
        }
        #endregion
    }
}
