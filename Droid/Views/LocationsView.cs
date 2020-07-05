
using Android.App;
using Android.OS;
using Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace Droid.Views
{
 
    [Activity(MainLauncher = true, Label = "Locations")]
    public class LocationsView : MvxActivity<LocationViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LocationList);
        }
    }
}