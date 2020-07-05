
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using Core.ViewModels;
using MvvmCross.Platforms.Android.Views;
using System;

namespace Droid.Views
{
 
    [Activity(MainLauncher = true, Label = "Locations")]
    public class LocationListView : MvxActivity<LocationListViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LocationList);


        }


    }
}