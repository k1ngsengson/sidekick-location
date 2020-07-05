using Core.Models;
using Core.Services;
using Data.Entities;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Common;
using Geocoding.Google;
using Geocoding;
using System.Linq;

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


        public ICommand ItemSelectedCommand
        {
            get { return new MvxCommand(OnItemSelected); }
        }

        private async void OnItemSelected()
        {
            var addressInfo = await _googleMapService.GetPlaceDetails(SelectedAddress.PlaceId);

            if (addressInfo != null)
            {
                bool save = await _service.AddLocationAsync(addressInfo);

                if (save)
                    await _navigationService.Navigate<LocationListViewModel, AddressInfo>(addressInfo);
            }
        }


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
    }
}
