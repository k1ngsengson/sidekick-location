using Android.App;
using Android.OS;
using Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace Droid.Views
{
    [Activity(Label = "Add Location")]
    public class LocationsItemView : MvxActivity<LocationItemViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LocationItem);
        }
    }
}