
using Acr.UserDialogs;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Core.ViewModels;
using MvvmCross.Platforms.Android.Views;
using System.Linq;

namespace Droid.Views
{

    [Activity(MainLauncher = true, Label = "Locations")]
    public class LocationListView : MvxActivity<LocationListViewModel>, IOnMapReadyCallback
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LocationList);

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }

        GoogleMap googleMap;

        public void OnMapReady(GoogleMap map)
        {
            googleMap = map;

            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            googleMap.UiSettings.MyLocationButtonEnabled = true;
            AddMarkersToMap();
        }

        void AddMarkersToMap()
        {
            if (ViewModel.Addresses.Count > 0)
            {
                foreach (var address in ViewModel.Addresses)
                {
                    var latLong = new LatLng(address.Latitude, address.Longitude);

                    var marker = new MarkerOptions();
                    marker.SetPosition(latLong)
                              .SetTitle(address.Address)
                              .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
                    googleMap.AddMarker(marker);
                }

                // We create an instance of CameraUpdate, and move the map to it.
                var firstAddress = ViewModel.Addresses.First();
                var firstLatLong = new LatLng(firstAddress.Latitude, firstAddress.Longitude);
                var cameraUpdate = CameraUpdateFactory.NewLatLngZoom(firstLatLong, 15);
                googleMap.MoveCamera(cameraUpdate);
            }
            
        }
    }
}