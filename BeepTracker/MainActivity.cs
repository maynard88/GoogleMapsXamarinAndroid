using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace BeepTracker
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, IOnMapReadyCallback
    {

		public void OnMapReady(GoogleMap googleMap)
		{
			MarkerOptions markerOptions = new MarkerOptions();

			// TODO: Allow app to ask permission for user to get LATLANG. 
			LatLng myPos = new LatLng(10.340360, 123.909882);

			markerOptions.SetPosition(myPos);
			markerOptions.SetTitle("You are here!");
			googleMap.AddMarker(markerOptions);			

			// Optional
			googleMap.UiSettings.ZoomControlsEnabled = true;
			googleMap.UiSettings.CompassEnabled = true;


			// Update Camera	
			googleMap.MoveCamera(CameraUpdateFactory.NewLatLng(myPos));
			googleMap.AnimateCamera(CameraUpdateFactory.ZoomTo(17));





		}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

			MapFragment mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
			mapFragment.GetMapAsync(this);


		}
    }
}